using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Week7Threading
{
    /// <summary>
    /// Something to be mined by a MineralMiner. Minerals have a particular mining time and base value.
    /// </summary>
    public class Mineral: IMine
    {
        public string MineralName { get; }
        public int MiningTime { get; }
        public int BaseValue { get; }

        /// <summary>
        /// A mineral that is capable of being mined by the MineralMiner. 
        /// </summary>
        /// <param name="mineralName"> The name of the mineral. </param>
        /// <param name="miningTime"> How long it takes to mine. </param>
        /// <param name="baseValue"> How much it is worth. </param>
        public Mineral(string mineralName, int miningTime, int baseValue)
        {
            MineralName = mineralName;
            MiningTime = miningTime;
            BaseValue = baseValue;
        }

        /// <summary>
        /// Sets a thread in motion to mine a particular mineral.
        /// </summary>
        public void Mine()
        {
            Thread.Sleep(MiningTime);
            Console.WriteLine($"You have just mined {MineralName}!");
        }

    }
}
