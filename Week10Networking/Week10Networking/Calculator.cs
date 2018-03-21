using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Week10Networking
{
    /// <summary>
    /// A web server program that performs basic math arithmatic.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// The entry point for the program.
        /// </summary>
        /// <param name="args">Launch arguments (HTTP server port).</param>
        public static void Main(string[] args)
        {
            /*
            * Un-comment the following line if you'd like to test this program without compiling into a .exe file.
            * The default port will be 1234. You will also need to un-comment line 39.
            * Warning: please do not run any unit tests when un-commenting these lines, as they may hang or fail
            * unexpectedly.
            */
            
            // args = new string[] { "1234" };

            if (args.Length == 1)
            {
                try
                {
                    int port = Convert.ToInt32(args[0]);

                    if(port > 1024 && port <= 65565)
                    {
                        RunServer(port);
                        Console.WriteLine($"The server is running on port {port} - press Enter to stop the server.");
                        // Console.ReadLine();
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("This program only accepts port values between 1024 (exclusive) and 65565 (inclusive).");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The number you supplied could not be converted into an Integer. Please provide a valid number between 1024 and 65565.");
                    throw;
                }
            }
            else
            {
                throw new ArgumentException("Wrong number of arguments supplied");
            }
        }
        
        /// <summary>
        /// A background (asynchronous) thread to handle incoming API requests.
        /// </summary>
        /// <param name="port">The server port to listen on.</param>
        private async static void RunServer(int port)
        {
            var uri = new UriBuilder("http", "localhost", port);
            var httpListener = new HttpListener();

            httpListener.Prefixes.Add(uri.ToString());
            httpListener.Start();

            while (true)
            {
                try
                {
                    var httpContext = await httpListener.GetContextAsync();
                    await Task.Run(() => PerformMathCalculations(httpContext));
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
        }

        /// <summary>
        /// Performs the acutal math arithmatic for each individual API request, done asynchronously.
        /// </summary>
        /// <param name="context">The Http context to use for this request.</param>
        private static void PerformMathCalculations(HttpListenerContext context)
        {
            try
            {
                int n1 = Convert.ToInt32(context.Request.QueryString["first"]);
                int n2 = Convert.ToInt32(context.Request.QueryString["second"]);
                string op = context.Request.QueryString["operation"];
                int result = 0;

                switch (op)
                {
                    case "add":
                        goto default;
                    case "subtract":
                        result = n1 - n2;
                        break;
                    case "multiply":
                        result = n1 * n2;
                        break;
                    default:
                        result = n1 + n2;
                        Console.WriteLine($"The operation \"{op}\" is not supported - defaulting to \"add\".");
                        break;
                }

                var httpResponse = context.Response;
                string respMessage = $"Your result is {result}!";

                Console.WriteLine($"Received a request to {op} numbers {n1} and {n2} - result is {result}");

                byte[] buf = System.Text.Encoding.UTF8.GetBytes(respMessage);
                httpResponse.ContentLength64 = buf.Length;
                Stream output = httpResponse.OutputStream;
                output.Write(buf, 0, buf.Length);

                output.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("One or more query string parameters supplied was invalid.");
            }
        }
    }
}
