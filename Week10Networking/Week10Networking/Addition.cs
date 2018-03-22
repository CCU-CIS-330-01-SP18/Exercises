using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Week10Networking
{
    /// <summary>
    /// A console app for adding two integers in your browser.
    /// </summary>
    public class Addition
    {
        /// <summary>
        /// The automatically-run console app method.
        /// </summary>
        /// <param name="args">Accepts a four-digit port number in the form of a string array.</param>
        static void Main(string[] args)
        {
            HttpMath(args);
        }

        /// <summary>
        /// Listens for Http Requests with two query parameters on a specified port.
        /// </summary>
        /// <param name="args">Accepts a four-digit port number in the form of a string array.</param>
        public async static void HttpMath(string[] args)
        {
            using (HttpListener listener = new HttpListener())
            {
                UriBuilder uri;
                int x, y;
                string returnValue, responseString;

                try
                {
                    uri = LocalUriBuilder(args);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid Port Number: " + e.Message);
                    return;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Invalid Console Arguments: " + e.Message);
                    return;
                }

                listener.Prefixes.Add(uri.ToString());
                listener.Start();

                var context = await listener.GetContextAsync();
                var request = context.Request;
                var response = context.Response;

                // Attempts to parse query string parameters to integers.
                try
                {
                    x = Convert.ToInt32(request.QueryString.GetValues(0)[0]);
                    y = Convert.ToInt32(request.QueryString.GetValues(1)[0]);
                    returnValue = Convert.ToString(x + y);
                }
                catch (Exception e) when (e is FormatException || e is ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Invalid Query String Arguments: " + e.Message);
                    returnValue = "Invalid Query String Arguments: " + e.Message;
                    return;
                }

                // Construct a response.
                responseString = returnValue;
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                var output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                // Close the output stream.
                output.Close();
                listener.Stop();
            }
        }

        /// <summary>
        /// Validates the argument as a four-digit port number.
        /// </summary>
        /// <param name="args">Accepts a four-digit port number in the form of a string array.</param>
        /// <returns>A UriBuilder.</returns>
        public static UriBuilder LocalUriBuilder(string[] args)
        {
            var consoleInput = ArgsToPort(args);

            if (Regex.IsMatch(Convert.ToString(consoleInput), @"^[1-9]{1}\d{3}$"))
            {
                int portNumber = Convert.ToInt16(consoleInput);
                return new UriBuilder("http", "localhost", portNumber);
            }
            else
            {
                throw new FormatException("Doesn't match 4-digit port format.");
            }
        }

        /// <summary>
        /// Validates a string array as one integer.
        /// </summary>
        /// <param name="args">Accepts a four-digit port number in the form of a string array.</param>
        /// <returns>A four-digit port number.</returns>
        public static int ArgsToPort(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Console.WriteLine("No arguments passed, defaulting to port 8001.");
                    return 8001;
                case 1:
                    return Convert.ToInt32(args.First());
                default:
                    throw new ArgumentException("No overload for more than one argument.");
            }
        }
    }
}