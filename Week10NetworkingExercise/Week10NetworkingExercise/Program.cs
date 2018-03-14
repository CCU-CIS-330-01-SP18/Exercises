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

            if (args.Length == 0)
            {
                throw new ArgumentNullException("No Command Line Argument Was Given");
            }

            WebServer.ListenForResponseAsync(portNumber);
        }
    }
}
