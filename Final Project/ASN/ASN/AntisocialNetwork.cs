using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ASN
{
    /// <summary>
    /// The core class for the AntisocialNetwork project.
    /// </summary>
    public class AntisocialNetwork
    {
        /// <summary>
        /// A collection of User instances.
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// A collection of Post instances.
        /// </summary>
        public List<Post> Posts { get; set; }

        /// <summary>
        /// Constructs a new instance of the social network server.
        /// </summary>
        public AntisocialNetwork()
        {
            Users = DataSerializer.DeserializeUsers();
            Posts = DataSerializer.DeserializePosts();

            RunServer(8080);
            Console.ReadLine();

            DataSerializer.SerializeUsers(Users);
            DataSerializer.SerializePosts(Posts);

            // Program terminates here.
        }

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">An array of command line arguments.</param>
        static void Main(string[] args)
        {
            new AntisocialNetwork();
        }

        /// <summary>
        /// Generates the next user ID in the sequence, making sure to always produce the next highest number.
        /// </summary>
        /// <returns>An integer for the user ID.</returns>
        public int GetNextUserID()
        {
            int id = 0;

            foreach (var user in Users)
            {
                if (user.UserID >= id)
                {
                    id = user.UserID + 1;
                }
            }

            return id;
        }

        /// <summary>
        /// Generates the next post ID in the sequence, making sure to always produce the next highest number.
        /// </summary>
        /// <returns>An integer for the post ID.</returns>
        public int GetNextPostID()
        {
            int id = 0;

            foreach (var post in Posts)
            {
                if (post.PostID >= id)
                {
                    id = post.PostID + 1;
                }
            }

            return id;
        }

        /// <summary>
        /// An asynchronous method to run our web server on. This creates a new thread for each API call.
        /// </summary>
        /// <param name="port">The port to run the server on.</param>
        private async void RunServer(int port)
        {
            Console.WriteLine("Starting server...");

            var uri = new UriBuilder("http", "localhost", port);
            var httpListener = new HttpListener();

            httpListener.Prefixes.Add(uri.ToString());
            httpListener.Start();

            Console.WriteLine($"Server is listening on port {port}.");

            while (true)
            {
                try
                {
                    var httpContext = await httpListener.GetContextAsync();
                    await Task.Run(() => RetrieveHttpData(httpContext));
                }
                catch (HttpListenerException)
                {
                    break;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }

            httpListener.Stop();

            Console.WriteLine("Server closed.");
        }

        /// <summary>
        /// The logic behind an individual API call thread. This parses the data received and makes changes accordingly.
        /// </summary>
        /// <param name="context">The HttpListenerContext of the call.</param>
        private void RetrieveHttpData(HttpListenerContext context)
        {
            string method = context.Request.HttpMethod;
            var queryStrings = context.Request.QueryString;
            var queryKeys = queryStrings.AllKeys;
            string url = context.Request.RawUrl;
            var headers = context.Request.Headers;
            var authenticatedUser = GetAuthenticatedUser(headers);

            context.Response.AddHeader("Access-Control-Allow-Origin", "*");

            if (method == "OPTIONS")
            {
                context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                context.Response.AddHeader("Access-Control-Allow-Headers", "email, password, content-type, test, hash");
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.Close();
                return;
            }

            if (method == "GET")
            {
                if (authenticatedUser != null)
                {
                    if (url.StartsWith("/post"))
                    {
                        if (queryStrings["id"] != null)
                        {
                            int id = Convert.ToInt32(queryStrings["id"]);
                            var post = GetPostByID(id);

                            if (post != null)
                            {
                                string serialized = JsonConvert.SerializeObject(post);

                                StreamOutput(context, System.Text.Encoding.UTF8.GetBytes(serialized));
                                context.Response.StatusCode = (int)HttpStatusCode.OK;
                            }
                            else
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                    }
                    else if (url.StartsWith("/userbyid"))
                    {
                        if (queryStrings["id"] != null)
                        {
                            int id = Convert.ToInt32(queryStrings["id"]);
                            var user = GetUserByID(id);
                            string serialized = JsonConvert.SerializeObject(user);

                            StreamOutput(context, System.Text.Encoding.UTF8.GetBytes(serialized));
                            context.Response.StatusCode = (int)HttpStatusCode.OK;
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                    }
                    else if (url.StartsWith("/user"))
                    {
                        string serialized = JsonConvert.SerializeObject(authenticatedUser);

                        StreamOutput(context, System.Text.Encoding.UTF8.GetBytes(serialized));
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    else if (url.StartsWith("/all"))
                    {
                        var posts = Posts.OrderByDescending(p => p.Posted).ToList();
                        string serialized = JsonConvert.SerializeObject(posts);

                        StreamOutput(context, System.Text.Encoding.UTF8.GetBytes(serialized));
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    }
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
            }
            else if (method == "POST")
            {
                var data = "";

                using (var reader = new StreamReader(context.Request.InputStream))
                {
                    data = reader.ReadToEnd();
                }

                var json = JObject.Parse(data);

                if (url.StartsWith("/login"))
                {
                    var user = GetAuthenticatedUser(headers);

                    if (user != null)
                    {
                        StreamOutput(context, Encoding.UTF8.GetBytes(user.HashedPassword));
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    }
                }
                else if (url.StartsWith("/register"))
                {
                    try
                    {
                        var firstName = json["firstName"].ToString();
                        var lastName = json["lastName"].ToString();
                        var email = json["email"].ToString();
                        var pass = json["password"].ToString();

                        // Because two or more users may share the same password, store it as a hash along with their email address.
                        var hashedPass = PasswordHasher.HashPassword(email + pass);

                        if (!RegexHandler.Name(firstName) || !RegexHandler.Name(lastName) || !RegexHandler.Email(email))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            context.Response.Close();
                            return;
                        }

                        // Check that a user with the same email address does not already exist.
                        foreach (var user in Users)
                        {
                            if (user.EmailAddress == email)
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                                context.Response.Close();
                                return;
                            }
                        }

                        // Create the new user.
                        var newUser = new User(firstName, lastName, email, GetNextUserID(), hashedPass);
                        Users.Add(newUser);

                        StreamOutput(context, Encoding.UTF8.GetBytes(newUser.HashedPassword));
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    catch (JsonException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    if (authenticatedUser != null)
                    {
                        if (url.StartsWith("/newpost"))
                        {
                            try
                            {
                                if (authenticatedUser.Points > 0)
                                {
                                    authenticatedUser.Points -= 1;

                                    var message = json["message"].ToString();
                                    var newPost = new Post(authenticatedUser.UserID, message, GetNextPostID());

                                    Posts.Add(newPost);
                                    StreamOutput(context, System.Text.Encoding.UTF8.GetBytes(newPost.PostID.ToString()));
                                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                                }
                                else
                                {
                                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                }
                            }
                            catch (JsonException)
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            }
                            catch (RuntimeBinderException)
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            }
                        }
                        else if (url.StartsWith("/givepoint"))
                        {
                            if (queryStrings["id"] != null)
                            {
                                if (authenticatedUser != null)
                                {
                                    int id = Convert.ToInt32(queryStrings["id"]);
                                    var post = GetPostByID(id);

                                    if (post != null)
                                    {
                                        post.AddPoint(authenticatedUser);

                                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                                        StreamOutput(context, System.Text.Encoding.UTF8.GetBytes(post.Points.ToString()));
                                    }
                                    else
                                    {
                                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                    }
                                }
                                else
                                {
                                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                }
                            }
                            else
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            }
                        }
                        else if (url.StartsWith("/addcomment"))
                        {
                            if (queryStrings["pid"] != null)
                            {
                                try
                                {
                                    int postID = Convert.ToInt32(queryStrings["pid"]);
                                    string message = json["message"].ToString();
                                    var post = GetPostByID(postID);

                                    if (post != null)
                                    {
                                        var newComment = post.AddComment(authenticatedUser.UserID, message);

                                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                                        StreamOutput(context, System.Text.Encoding.UTF8.GetBytes(newComment.PostID.ToString()));
                                    }
                                    else
                                    {
                                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                    }
                                }
                                catch (JsonException)
                                {
                                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                }
                                catch (RuntimeBinderException)
                                {
                                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                }
                            }
                            else
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    }
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
            }

            context.Response.Close();
        }

        /// <summary>
        /// Takes in a list of HTTP headers, and compares their values with the objects in memory to authenticate a user.
        /// </summary>
        /// <param name="headers">The NameValueCollection list of headers to use.</param>
        /// <returns>A User, if authenticated. Otherwise, returns null.</returns>
        private User GetAuthenticatedUser(NameValueCollection headers)
        {
            if (headers["email"] != null && headers["password"] != null)
            {
                string email = headers["email"];
                string pass = headers["password"];

                foreach (var u in Users)
                {
                    var hashed = PasswordHasher.HashPassword(email + pass);

                    if (u.EmailAddress.Equals(email) && u.HashedPassword.Equals(hashed))
                    {
                        string today = DateTime.Today.ToString("dd-MM-yyyy");

                        if (!u.LastLogin.Equals(today))
                        {
                            u.LastLogin = today;
                            u.Points += 3;
                        }

                        return u;
                    }
                }
            }
            else if (headers["hash"] != null)
            {
                var value = headers["hash"];

                foreach (var u in Users)
                {
                    if (u.HashedPassword == value)
                    {
                        return u;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Streams some data to the user as part of the API call's response.
        /// </summary>
        /// <param name="context">The context of our response to use.</param>
        /// <param name="data">The byte array of data to stream.</param>
        private void StreamOutput(HttpListenerContext context, byte[] data)
        {
            context.Response.ContentLength64 = data.Length;

            using (var s = context.Response.OutputStream)
            {
                s.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        /// Attempts to match a Post object with its ID.
        /// </summary>
        /// <param name="id">The ID to use.</param>
        /// <returns>A Post object if found; otherwise, returns null.</returns>
        private Post GetPostByID(int id)
        {
            foreach (var item in Posts)
            {
                if (item.PostID == id)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Attempts to match a User object with their ID.
        /// </summary>
        /// <param name="id">The ID to use.</param>
        /// <returns>A User object if found; otherwise, returns null.</returns>
        private User GetUserByID(int id)
        {
            foreach (var item in Users)
            {
                if (item.UserID == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
 }
 