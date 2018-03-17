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
            UriBuilder uri = new UriBuilder("http", "localhost", portNumber);

            WebServer.ListenForResponseAsync(portNumber);

            Console.WriteLine($"Listening... On Port {portNumber}, press enter to stop.");
            Console.ReadLine();
        }
    }
}
