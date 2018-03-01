using System;
using System.Collections.Generic;
using System.Text;

namespace Week7Threading
{
    /// <summary>
    /// A type of mineral that is worth 5.
    /// </summary>
    class Silver: Mineral
    {
        public Silver(): base("Silver", 2000, 5)
        {
        }
        /// <summary>
        /// Finds silver and gives a MineralMiner the opportunity to mine it.
        /// </summary>
       public void FindSilver()
        {
            Console.WriteLine("You have found silver! Type \"mine silver\" to mine!");
        }
    }
}
