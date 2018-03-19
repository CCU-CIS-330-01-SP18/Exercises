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

            if (!xIsNumber && yIsNumber)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.OutputStream.Close();
            }

            if (!string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
            {
                int result = firstNumber + secondNumber;

                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(result.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                using (StreamWriter writer = new StreamWriter(context.Response.OutputStream))
                {
                    writer.Write(result);
                }
            }
            else
            {
                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(responseString.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                using (StreamWriter writer = new StreamWriter(context.Response.OutputStream))
                {
                    writer.Write(responseString);
                }
                /*context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.OutputStream.Close();*/
            }
        }
    }
}
