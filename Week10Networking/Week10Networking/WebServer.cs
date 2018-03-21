using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Week10Networking
{
    /// <summary>
    /// A static class responsible for serving HTTP requests.
    /// </summary>
    public class WebServer
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">An array of arguments passed into the program upon execution. The first index should be a valid port number.</param>
        private static void Main(string[] args)
        {
            string invalidPortMessage = "Invalid port number supplied. Please supply a valid port number to listen on.";
            if (args.Length < 1)
            {
                Console.WriteLine("Please supply a port number to listen on.");
                return;
            }
            try
            {
                RunWebListener(ParseArgument(args[0]));
            }
            catch (FormatException)
            {
                Console.WriteLine(invalidPortMessage);
            }
            catch (OverflowException)
            {
                Console.WriteLine(invalidPortMessage);
            }
            finally
            {
                Console.WriteLine("Exiting...");
            }
        }

        /// <summary>
        /// Takes the given argument and determines whether or not it is a valid port number, returning it in unsigned 16-bit integer (ushort) format if it is.
        /// </summary>
        /// <param name="argument">A raw argument in string format, passed into the program.</param>
        /// <returns>A valid port number in ushort format.</returns>
        public static ushort ParseArgument(string argument)
        {
            // Port numbers are unsigned 16-bit integers.
            return Convert.ToUInt16(argument);
        }

        /// <summary>
        /// Runs the web listener on the given port.
        /// </summary>
        /// <param name="portNumber">A valid port number to listen on.</param>
        public static void RunWebListener(ushort portNumber)
        {
            var uri = new UriBuilder("http", "localhost", portNumber);
            Console.WriteLine("Listening for requests on port " + portNumber.ToString());

            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add(uri.ToString());
                listener.Start();
                while (true)
                {
                    var context = listener.GetContext();
                    var request = context.Request;
                    var response = context.Response;
                    string responseString = "<html><body>";
                    double? x = null;
                    double? y = null;

                    try
                    {
                        if (request.QueryString.HasKeys() &&
                            request.QueryString.Get("x") != null &&
                            request.QueryString.Get("y") != null)
                        {
                            x = Convert.ToDouble(request.QueryString.Get("x"));
                            y = Convert.ToDouble(request.QueryString.Get("y"));
                        }
                    }
                    catch (InvalidCastException) { }

                    if (x == null || y == null)
                    {
                        responseString += "<p>Invalid query string entered. Please try again.</p>";
                    }
                    else
                    {
                        responseString += $"<p>{x} + {y} = {x + y}</p>";
                    }

                    responseString += "</body></html>";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                    response.ContentLength64 = buffer.Length;
                    var output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);

                    output.Close();
                }
            }
        }
    }
}
