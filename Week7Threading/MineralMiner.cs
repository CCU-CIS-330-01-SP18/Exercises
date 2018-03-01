using System;
using System.Threading;
using System.Threading.Tasks;

namespace Week7Threading
{
    /// <summary>
    /// A class to implement a mineral miner capable of mining various minerals.
    /// </summary>
    public static class MineralMiner
    {
        public static bool MiningSilver { get; set; }
        public static bool MiningGold { get; set; }
        public static bool MiningUnobtanium { get; set; }

        private static Silver _silver = new Silver();
        private static Gold _gold = new Gold();
        private static Unobtanium _unobtanium = new Unobtanium();

        /// <summary>
        /// Begins the process of mining a particular mineral.
        /// </summary>
        /// <param name="mineral"> The mineral that is to be mined. </param>
        public static void Mine(string mineral)
        {
            if (mineral == "silver")
            {
                if (MiningSilver)
                {
                    Console.WriteLine("You are already mining that! Mine something else!");
                    return;
                }

                Console.WriteLine("Mining Silver! Feel free to start mining something else!");
                MiningSilver = true;
                Task.Run(() =>
                {
                    Thread.Sleep(_silver.MiningTime);
                    Console.WriteLine("You mined silver! Keep mining!");
                    MiningSilver = false;
                });
            }
        }


    }
}
