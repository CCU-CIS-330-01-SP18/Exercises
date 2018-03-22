using System;
using System.Collections.Generic;
using System.Linq;


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
                WebServer.ListenAsync(portNumber);
                Console.WriteLine($"Listening on port {portNumber}, press any key to stop.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Enter in the port number again, an error occured.");
            }
        }
    }
}