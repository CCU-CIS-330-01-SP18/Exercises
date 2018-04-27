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
    public class AntisocialNetwork
    {
        public List<User> Users { get; set; }

        public List<Post> Posts { get; set; }

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

        static void Main(string[] args)
        {
            new AntisocialNetwork();
        }

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
                        if (queryStrings["id"] != null) {
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

                using (StreamReader reader = new StreamReader(context.Request.InputStream))
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
                        var hashedPass = PasswordHasher.HashPassword(email+pass);

                        if (!RegexHandler.Name(firstName) || !RegexHandler.Name(lastName) || !RegexHandler.Email(email))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
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

                        var newUser = new User(firstName, lastName, email, GetNextUserID(), hashedPass);
                        Users.Add(newUser);

                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        StreamOutput(context, Encoding.UTF8.GetBytes(newUser.UserID.ToString()));
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
                                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                                    StreamOutput(context, System.Text.Encoding.UTF8.GetBytes(newPost.PostID.ToString()));
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

        private User GetAuthenticatedUser(NameValueCollection headers)
        {
            if (headers["email"] != null && headers["password"] != null)
            {
                string email = headers["email"];
                string pass = headers["password"];

                foreach (var u in Users)
                {
                    var hashed = PasswordHasher.HashPassword(email+pass);

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

        private void StreamOutput(HttpListenerContext context, byte[] data)
         {
             context.Response.ContentLength64 = data.Length;

             using (var s = context.Response.OutputStream)
             {
                 s.Write(data, 0, data.Length);
             }
         }

         private Post GetPostByID(int id)
         {
             foreach(var item in Posts)
             {
                 if(item.PostID == id)
                 {
                     return item;
                 }
             }

             return null;
         }

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
 