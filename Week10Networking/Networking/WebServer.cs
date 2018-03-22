using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    /// <summary>
    /// Takes a user defined port number, and on the users localhost, adds two query string paramaters together.
    /// </summary>
    public class WebServer
    {
        /// <summary>
        /// Take the user console input and validate that it is properly formatted for a port number, then start up the web server if it is.
        /// </summary>
        /// <param name="args">
        /// The port number the user types in on the console.
        /// </param>
        public static void Main(string[] args)
        {
            int portNumber;

            // Try to convert the input arguments to numbers.
            try
            {
                bool test = int.TryParse(args[0], out portNumber);
                if (test == true)
                {
                    if (args.Length > 1 || args.Length < 1)
                    {
                        Console.WriteLine("You did not only enter a port number as a command-line argument.");
                    }
                    else
                    {
                        StartUpServer(portNumber);
                    }
                }
                else
                {
                    Console.WriteLine("You did not enter a port number as a command-line argument.");
                }
            }
            catch (IndexOutOfRangeException)
            {
                 Console.WriteLine("Please enter a port number as a command-line argument.");
            }


        }

        /// <summary>
        /// Starts up the web server, then calls an async method so that it doesn't have to be restarted every time it's refreshed.
        /// </summary>
        /// <param name="portNumber">
        /// The port number the user already typed in to host the server on.
        /// </param>
        private static void StartUpServer(int portNumber)
        {
            var uri = new UriBuilder("http", "localhost", portNumber);

            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add(uri.ToString());
                listener.Start();

                Console.WriteLine("I'm waiting...");

                var context = listener.GetContext();
                var request = context.Request;

                var response = context.Response;

                string responseString = "<HTML><BODY> Coding is hard... so here's some math I guess.</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                // Terminate the output stream.
                output.Close();
                listener.Stop();
            }

            GenerateWebServerAsync(portNumber, uri);

            Console.WriteLine($"Server running on port {portNumber}. Press Enter to stop.");
            Console.ReadLine();
        }

        /// <summary>
        /// Allows the web server to be asynchronous.
        /// </summary>
        /// <param name="portNumber">
        /// The port number the user already typed in to host the server on.
        /// </param>
        /// <param name="uri">
        /// The URI which was used to start the web server.
        /// </param>
        public async static void GenerateWebServerAsync(int portNumber, UriBuilder uri)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(uri.ToString());
            listener.Start();

            while (true)
            {
                try
                {
                    var context = await listener.GetContextAsync();
                    await Task.Run(() => ProcessRequestAsync(context));
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

            listener.Stop();
        }

        /// <summary>
        /// Performs format testing on the paramaters given by the user, and if correct, will add them together.
        /// </summary>
        /// <param name="context">
        /// Info on the listener.
        /// </param>
        public static void ProcessRequestAsync(HttpListenerContext context)
        {

            if (context.Request.QueryString.HasKeys())
            {

                try
                {
                    int x = Convert.ToInt32(context.Request.QueryString["x"]);
                    int y = Convert.ToInt32(context.Request.QueryString["y"]);

                    int result = x + y;

                    context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(result.ToString());
                    context.Response.StatusCode = (int)HttpStatusCode.OK;

                    using (var writer = new StreamWriter(context.Response.OutputStream))
                    {
                        writer.Write(result);
                    }
                }
                catch (FormatException)
                {
                    string response = "Please provide two query string paramaters which are integers. One should be named 'x' and the other 'y'.";
                    FormatFailure(context, response);
                }
                
            }
            else
            {
                string response = "Please provide two query string paramaters which are integers. One should be named 'x' and the other 'y'.";
                FormatFailure(context, response);
            } 
        }

        /// <summary>
        /// If the format for the query string was incorrect, this method deal with the response that should be provided to the user.
        /// </summary>
        /// <param name="context">
        /// Info on the listener.
        /// </param>
        /// <param name="response">
        /// The string that should be displayed for the user.
        /// </param>
        public static void FormatFailure(HttpListenerContext context, string response)
        {
            context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(response);
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            using (var writer = new StreamWriter(context.Response.OutputStream))
            {
                writer.Write(response);
            }
            context.Response.OutputStream.Close();
        }
    }
}
