using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using System.Linq;

namespace Week10Networking
{
    /// <summary>
    /// A class to create an HTTPListener.
    /// </summary>
    class WebServer
    {
        /// <summary>
        /// Starts async process and accepts a port number for networking purposes.
        /// </summary>
        /// <param name="portNumber">The port number that is specified in Program.cs.</param>
        public static async void RunListenerAsync(int portNumber)
        {
            UriBuilder uri = new UriBuilder("http", "localhost", portNumber);

            HttpListener listener = new HttpListener();

            listener.Prefixes.Add(uri.ToString());
            listener.Start();

            Console.WriteLine("I can hear you...");

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
        /// Performs the logic for integer addition and also validates input.
        /// </summary>
        /// <param name="context">context that has been sent from the task in RunListernerAsync.</param>
        private static void ProcessRequestAsync(HttpListenerContext context)
        {
            string x = context.Request.QueryString["x"];
            string y = context.Request.QueryString["y"];
            string responseString = "<HTML><BODY>FAM! Give us some numbers and we will give you some math in return.</BODY></HTML>";

            int firstNumber;
            int secondNumber;

            bool xIsNumber = int.TryParse(x, out firstNumber);
            bool yIsNumber = int.TryParse(y, out secondNumber);

            if (!string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
            {
                int result = firstNumber + secondNumber;

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

