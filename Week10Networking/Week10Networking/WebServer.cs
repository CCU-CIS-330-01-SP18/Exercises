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
    class WebServer
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">An array of arguments passed into the program upon execution.</param>
        static void Main(string[] args)
        {
            int portNumber = 8001;
            var uri = new UriBuilder("http", "localhost", portNumber);

            while (true)
            {
                // TODO: This code will open and close the listener over and over...there's got to be a better way
                using (var listener = new HttpListener())
                {
                    listener.Prefixes.Add(uri.ToString());
                    listener.Start();

                    Console.WriteLine("Listening for requests on port " + portNumber.ToString());
                    
                    var context = listener.GetContext();
                    var request = context.Request;
                    
                    var response = context.Response;
                    
                    string responseString = "<HTML><BODY>CALCULATOR STUFF WILL GO HERE</BODY></HTML>";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    
                    response.ContentLength64 = buffer.Length;
                    var output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    
                    output.Close();
                    listener.Stop();
                }
            }
        }
    }
}
