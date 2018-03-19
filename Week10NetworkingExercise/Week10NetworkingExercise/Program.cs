using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10NetworkingExercise
{
    /// <summary>
    /// Entry point of this program that runs the webserver.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This method runs the program and establishes a port to listen on for requests and responses.
        /// </summary>
        /// <param name="args">Command line arguments that can be passed in, in this case the port number.</param>
        static void Main(string[] args)
        {
            int portNumber;
            bool validPortNumber = int.TryParse(args[0], out portNumber);

            if (validPortNumber)
            {
                WebServer.ListenForResponseAsync(portNumber);

                Console.WriteLine($"Listening... On Port {portNumber}, press enter to stop.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Strings that do not contain numbers are not valid port numbers, enter a command line argument that is a number.");
            }

            
        }
    }
}
