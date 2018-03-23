using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Week10Networking
{
    /// <summary>
    /// This program request a port number and utilizes the WebServer class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Validates port input and calls the RunListener Async method
        /// </summary>
        /// <param name="args">Port number to be passed in.</param>
        static void Main(string[] args)
        {
            int portNumber;
            
            bool isValid = int.TryParse(args[0], out portNumber);

            if (isValid)
            {
                WebServer.RunListenerAsync(portNumber);

                Console.WriteLine($"Port Number: {portNumber}, pressing enter will stop.");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine($"String must contain numbers.");
            }    
        }
    }
}
