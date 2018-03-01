using System;
using System.Collections.Generic;
using System.Text;

namespace Week7Threading
{
    /// <summary>
    /// A type of mineral that is worth 10.
    /// </summary>
    class Gold: Mineral
    {
        public Gold() : base("Gold", 5000, 10)
        {
        }
        /// <summary>
        /// Finds gold and gives a MineralMiner the opportunity to mine it.
        /// </summary>
        public void FindGold()
        {
            Console.WriteLine("Yee Haw! You found gold!");
        }
    }
}
