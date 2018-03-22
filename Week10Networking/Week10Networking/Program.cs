using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Week10Networking
{
    /// <summary>
    /// A web server program that adds two numbers together.
    /// </summary>
    
    public class Program
    {
        /// <summary>
        /// Main Function - The entry point for the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int portNumber = 2018;
            
            if (portNumber == 2018)
            {
                StartServer(portNumber);

                Console.WriteLine($"Listening... On Port {portNumber}, press enter to stop.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Strings that do not contain numbers are not valid port numbers.");
            }

        }

        /// <summary>
        /// Starts the Server on the port number provided.
        /// </summary>
        /// <param name="portNumber"> Is the port number that the server uses</param>
        public async static void StartServer(int portNumber)
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
                    await Task.Run(() => PerformMathCalculations(context));
                }
                catch (HttpListenerException) { break; }
                catch (InvalidOperationException) { break; }
            }

            listener.Stop();
        }

        /// <summary>
        /// Adds two numbers together.
        /// </summary>
        /// <param name="context">The numbers provided from the HTTP request.</param>
        
        private static void PerformMathCalculations(HttpListenerContext context)
        {
            string x = context.Request.QueryString["x"];
            string y = context.Request.QueryString["y"];
            
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

                using (var writer = new StreamWriter(context.Response.OutputStream))
                {
                    writer.Write(result);
                }
            }
            else
            {
                using (var writer = new StreamWriter(context.Response.OutputStream))
                {
                    writer.Write("Numbers entered invalid");
                }
            }
        }

    }
}
