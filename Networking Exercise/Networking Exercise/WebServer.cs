﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;

namespace NetworkingExercise
{
    /// <summary>
    /// 
    /// </summary>
    public class WebServer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        public static async void ListenAsync(int portNumber)
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
                    await Task.Run(() => ProcessAsync(context));
                }
                catch (HttpListenerException) { break; }
                catch (InvalidOperationException) { break; }
            }

            listener.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public static void ProcessAsync(HttpListenerContext context)
        {
            string x = context.Request.QueryString["x"];
            string y = context.Request.QueryString["y"];
            string responseString = "<HTML><BODY> Hello User! Put in some numbers!</BODY></HTML>";

            bool xIsNumber = int.TryParse(x, out int firstNumber);
            bool yIsNumber = int.TryParse(y, out int secondNumber);
            
            if (!string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
            {
                int result = firstNumber + secondNumber;

                if (result == 0)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.OutputStream.Close();
                    return;
                }

                using (var writer = new StreamWriter(context.Response.OutputStream))
                {
                    writer.Write(result);
                }
            }
            else
            {

                using (var writer = new StreamWriter(context.Response.OutputStream))
                {
                    writer.Write(responseString);
                }
            }
        }
    }
}