using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDisposing
{
    /// <summary>
    /// A class that definately does not implement iDisposable.
    /// </summary>
    public class NoDisposing
    {
        /// <summary>
        /// Method that writes Hello World, and does not implement iDisposeble. 
        /// </summary>
        /// <param name="args"></param>
        public static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
