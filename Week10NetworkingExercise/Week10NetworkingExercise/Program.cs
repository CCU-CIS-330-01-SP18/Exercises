using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10NetworkingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int portNumber;
            bool validPortNumber = int.TryParse(args[0], out portNumber);

            Console.WriteLine($"Listening... On Port {portNumber}, press enter to stop.");
            Console.ReadLine();

            if (args.Length == 0)
            {
                throw new IndexOutOfRangeException("No Command Line Argument Was Given For the Port Number to Listen on");
            }

            WebServer.ListenForResponseAsync(portNumber);
        }
    }
}
