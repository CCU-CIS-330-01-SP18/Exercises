using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NetworkingExercise
{
    /// <summary>
    /// 
    /// </summary>
    public class WebProgram
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        { 

            bool validPortNumber = int.TryParse(args[0], out int portNumber);

            if (validPortNumber)
            {
                try
                {
                    WebServer.ListenAsync(portNumber);
                    Console.WriteLine($"Listening on port {portNumber}, press any key to stop.");
                    Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect format. Please try again.");
                    throw;
                }

            }
            else
            {
                Console.WriteLine($"Enter in the port number again, an error occured.");
            }
        }
    }
}