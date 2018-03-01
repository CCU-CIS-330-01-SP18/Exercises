using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Week7Threading
{
    /// <summary>
    /// Something to be mined by a MineralMiner. Minerals have a particular mining time and base value.
    /// </summary>
    class Mineral: IMine
    {
        public string MineralName { get; }
        public int MiningTime { get; }
        public int BaseValue { get; }

        public Mineral(string mineralName, int miningTime, int baseValue)
        {
            MineralName = mineralName;
            MiningTime = miningTime;
            BaseValue = baseValue;
        }

        public void Mine()
        {
            Thread.Sleep(MiningTime);
            Console.WriteLine($"You have just mined {MineralName}!");
        }

    }
}
