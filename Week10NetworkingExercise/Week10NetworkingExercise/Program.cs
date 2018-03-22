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
            
            // NOTE: You can right click my solution in solution explorer, go to properties, then Debug to enter a argument.
            // Grabs the port number from the args if it can be parsed into an integer.
            bool validPortNumber = int.TryParse(args[0], out portNumber);

            // If it is a valid integer then run the server on the specified command line argument.
            if (validPortNumber)
            {
                WebServer.ListenForResponseAsync(portNumber);

                Console.WriteLine($"Listening... On Port {portNumber}, press enter to stop.");
                Console.ReadLine();
            }

            // An value was passed in that cannot be parsed into an integer i.e. 'hello'.
            else
            {
                Console.WriteLine($"Strings that do not contain numbers are not valid port numbers, enter a command line argument that is a number.");
            }    
        }
    }
}
