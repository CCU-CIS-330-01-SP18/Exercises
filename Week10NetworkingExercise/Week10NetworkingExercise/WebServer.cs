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
    public class WebServer
    {
        public async static void ListenForResponseAsync(int portNumber)
        {
            UriBuilder uri = new UriBuilder("http", "localhost", portNumber);

            HttpListener listener = new HttpListener();
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

        public static void ProcessRequestAsync(HttpListenerContext context)
        {
            string x = context.Request.QueryString["x"];
            string y = context.Request.QueryString["y"];

            int firstNumber;
            int secondNumber;

            bool xIsNumber = int.TryParse(x, out firstNumber);
            bool yIsNumber = int.TryParse(y, out secondNumber);

            if (xIsNumber || yIsNumber == false)
            {
                throw new InvalidOperationException("Both query strings must be integer values");
            }

            if (!string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
            {
                //string result = x + y;
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
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.OutputStream.Close();
            }
        }
    }
}
