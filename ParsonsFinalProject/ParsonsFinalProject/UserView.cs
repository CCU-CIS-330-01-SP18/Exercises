using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsonsFinalProject
{
    public class UserView
    {
        public string UserConsole()
        {
            Console.WriteLine("Write out the statement for audio conversion:");
            var speechText = Console.ReadLine();
            return speechText;
        }
    }
}
