using System;

namespace Week7Threading
{
    /// <summary>
    /// A class to implement a mineral miner capable of mining various minerals.
    /// </summary>
    public class MineralMiner
    {
        public bool FoundSilver { get; set; }
        public bool FoundGold { get; set; }
        public bool FoundUnobtanium { get; set; }
        public bool MiningSilver { get; set; }
        public bool MiningGold { get; set; }
        public bool MiningUnobtanium { get; set; }

        private Silver _silver = new Silver();
        private Gold _gold = new Gold();
        private Unobtanium _unobtanium = new Unobtanium();

        /// <summary>
        /// Begins the process of mining a particular mineral.
        /// </summary>
        /// <param name="mineral"> The mineral that is to be mined. </param>
        public void Mine(string mineral)
        {
            Console.WriteLine("You are now mining" + mineral + " !");
        }


    }
}
