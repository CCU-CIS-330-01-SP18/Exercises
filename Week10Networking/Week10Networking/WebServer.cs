using System;
using System.Net;
using System.Text;

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
        /// <param name="args">An array of arguments passed into the program upon execution. The first index should be a valid port number (<see cref="ushort"/>).</param>
        static void Main(string[] args)
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
            catch (HttpListenerException ex)
            {
                if (ex.Message.Contains("Access is denied"))
                {
                    Console.WriteLine("Access is denied. Please run this program as an administrator.");
                }
            }
            finally
            {
                Console.WriteLine("Exiting...");
            }
        }

        /// <summary>
        /// Takes the given argument and determines whether or not it is a valid port number, returning it in unsigned 16-bit integer (<see cref="ushort"/>) format if it is.
        /// </summary>
        /// <param name="argument">A raw argument in string format, passed into the program.</param>
        /// <returns>A valid port number in <see cref="ushort"/> format.</returns>
        /// <remarks>This method is public to facilitate unit testing.</remarks>
        public static ushort ParseArgument(string argument)
        {
            // Port numbers are unsigned 16-bit integers. This is in a separate method so that unit tests can check against it.
            return Convert.ToUInt16(argument);
        }

        /// <summary>
        /// Runs the web listener on the given port.
        /// </summary>
        /// <param name="portNumber">A valid port number to listen on.</param>
        /// <remarks>This method is public to facilitate unit testing.</remarks>
        public static void RunWebListener(ushort portNumber)
        {
            var uri = new UriBuilder("http", "localhost", portNumber);

            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add(uri.ToString());
                listener.Start();
                Console.WriteLine("Listening for requests on port " + portNumber.ToString());

                while (true)
                {
                    var context = listener.GetContext();
                    var request = context.Request;
                    var response = context.Response;
                    var output = response.OutputStream;
                    string responseString = "<html><body>";
                    int? x = null;
                    int? y = null;

                    // Check the query string to see if it has everything the program needs.
                    try
                    {
                        if (request.QueryString.HasKeys() &&
                            request.QueryString.Get("x") != null &&
                            request.QueryString.Get("y") != null &&
                            request.QueryString.Get("x").Length > 0 &&
                            request.QueryString.Get("y").Length > 0)
                        {
                            x = Convert.ToInt32(request.QueryString.Get("x"));
                            y = Convert.ToInt32(request.QueryString.Get("y"));
                        }
                        else
                        {
                            throw new ArgumentNullException("One or both parameters was not supplied.");
                        }
                    }
                    catch (FormatException)
                    {
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response.StatusDescription = "Bad values entered. Make sure the query string values are integers, and try again.";
                        responseString += "<p>Bad values entered. Make sure the query string values are integers, and try again.</p>";
                    }
                    catch (ArgumentNullException)
                    {
                        // Thrown if the query string is missing the x and y values.
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response.StatusDescription = "One or both values is missing. Please try again.";
                        responseString += "<p>One or both values is missing. Please try again.</p>";
                    }

                    if (x != null && y != null)
                    {
                        response.StatusCode = (int)HttpStatusCode.OK;
                        responseString += $"<p>{x} + {y} = {x + y}</p>";
                    }

                    responseString += "</body></html>";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                    response.ContentLength64 = buffer.Length;
                    output.Write(buffer, 0, buffer.Length);

                    output.Close();
                }
            }
        }
    }
}
