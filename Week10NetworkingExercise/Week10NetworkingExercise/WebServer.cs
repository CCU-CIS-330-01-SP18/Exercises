using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Net;
using System.Net.Http;
using System.IO;

namespace Week10NetworkingExercise
{
    /// <summary>
    /// Class which provides methods for creating an HttpListener and providing specific responses.
    /// </summary>
    public class WebServer
    {
        /// <summary>
        /// Method that listens for a response based on a specified port number.
        /// </summary>
        /// <param name="portNumber">The port on which the HttpListener should listen for.</param>
        public async static void ListenForResponseAsync(int portNumber)
        {
            var uri = new UriBuilder("http", "localhost", portNumber);

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
                catch (HttpListenerException) { break; }
                catch (InvalidOperationException) { break; }
            }
            listener.Stop();
        }

        /// <summary>
        /// Method that processes a request to the WebServer and directs responses which is either a message in the root
        /// directory, or adding two numbers when QueryString "x" and "y" are populated.
        /// </summary>
        /// <param name="context">context in which to work responses for.</param>
        public static void ProcessRequestAsync(HttpListenerContext context)
        {
            string x = context.Request.QueryString["x"];
            string y = context.Request.QueryString["y"];
            string responseString = "<HTML><BODY> Hello, welcome to my server! Input some numbers into the query paramaters x and y to add some numbers together.</BODY></HTML>";

            int firstNumber;
            int secondNumber;

            bool xIsNumber = int.TryParse(x, out firstNumber);
            bool yIsNumber = int.TryParse(y, out secondNumber);

            // If x and y have values then this condition will run.
            if (!string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
            {
                int result = firstNumber + secondNumber;

                // int.TryParse returns 0 if false, therefore when adding result if it's false, it will be 0.
                // Almost the equivalent of (!xIsNumber || !yIsNumber).
                // This condition will throw a bad request on query strings x=hello, y=world.
                if (result == 0)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.OutputStream.Close();
                    return;
                }

                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(result.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                using (var writer = new StreamWriter(context.Response.OutputStream))
                {
                    writer.Write(result);
                }
            }
            
            // If the root page is requested i.e. http://localhost:3001.
            else
            {
                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(responseString.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                using (var writer = new StreamWriter(context.Response.OutputStream))
                {
                    writer.Write(responseString);
                }
            }
        }
    }
}
