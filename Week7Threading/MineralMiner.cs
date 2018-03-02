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
        public static bool MiningUnobtainium { get; set; }

        private static Silver _silver = new Silver();
        private static Gold _gold = new Gold();
        private static Unobtainium _unobtainium = new Unobtainium();

        /// <summary>
        /// Determines what mineral you want to mine and if you are mining it.
        /// Then begins the process of mining that particular mineral.
        /// </summary>
        /// <param name="mineral"> The mineral that is to be mined. </param>
        public static void Mine(string mineral)
        {
            if (mineral == "silver")
            {
                if (MiningSilver)
                {
                    Console.WriteLine("You are already mining silver! Mine something else!");
                    return;
                }

                Console.WriteLine("Mining silver takes 5 seconds! Feel free to start mining something else!");
                MiningSilver = true;
                Task.Run(() =>
                {
                    Thread.Sleep(_silver.MiningTime);
                    Console.WriteLine("You mined silver! Keep mining!");
                    MiningSilver = false;
                });
            }
            if (mineral == "gold")
            {
                if (MiningGold)
                {
                    Console.WriteLine("You are already mining gold! Mine something else!");
                    return;
                }

                Console.WriteLine("Mining gold takes 10 seconds! Feel free to start mining something else!");
                MiningGold = true;
                Task.Run(() =>
                {
                    Thread.Sleep(_gold.MiningTime);
                    Console.WriteLine("You mined gold! Keep mining!");
                    MiningGold = false;
                });
            }
            if (mineral == "unobtainium")
            {
                if (MiningUnobtainium)
                {
                    Console.WriteLine("You are already mining unobtainium! Mine something else!");
                    return;
                }

                Console.WriteLine("Mining unobtainium takes 15 seconds! Feel free to start mining something else!");
                MiningUnobtainium = true;
                Task.Run(() =>
                {
                    Thread.Sleep(_unobtainium.MiningTime);
                    Console.WriteLine("You mined unobtainium! You're rich beyond your wildest dreams! Keep mining!");
                    MiningUnobtainium = false;
                });
            }
        }


    }
}
