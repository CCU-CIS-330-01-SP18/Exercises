using System;
using System.Collections.Generic;
using System.Text;

namespace Week7Threading
{
    /// <summary>
    /// A type of mineral that is worth 10,000.
    /// </summary>
    class Unobtanium: Mineral
    {
        public Unobtanium(): base("Unobtanium", 10000, 10000)
        {
        }
        /// <summary>
        /// Finds unobtanium and gives a MineralMiner the opportunity to mine it.
        /// </summary>
        public void FindUnobtanium()
        {
            Console.WriteLine("You have found unobtanium. Proceed with caution if you see any blue people.");
        }
    }
}
