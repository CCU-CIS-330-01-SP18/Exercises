using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;

namespace Week7ThreadingTests
{
    [TestClass]
    public class MineralMinerTests
    {
        [TestMethod]
        public void MiningSilverChangesMiningSilverProperty()
        {
            MineralMiner.Mine("silver");
            Assert.AreEqual(true, MineralMiner.MiningSilver);
            Thread.Sleep(5500);
            Assert.AreEqual(false, MineralMiner.MiningSilver);
        }
        [TestMethod]
        public void MiningGoldChangesMiningGoldProperty()
        {
            MineralMiner.Mine("gold");
            Assert.AreEqual(true, MineralMiner.MiningGold);
            Thread.Sleep(10500);
            Assert.AreEqual(false, MineralMiner.MiningGold);
        }
        [TestMethod]
        public void MiningUnobtainiumChangesMiningUnobtainiumProperty()
        {
            MineralMiner.Mine("unobtainium");
            Assert.AreEqual(true, MineralMiner.MiningUnobtainium);
            Thread.Sleep(15500);
            Assert.AreEqual(false, MineralMiner.MiningUnobtainium);
        }
        [TestMethod]
        public void CanMineMultipleMinerals()
        {
            MineralMiner.Mine("silver");
            MineralMiner.Mine("gold");
            Assert.AreEqual(MineralMiner.MiningSilver, true);
            Assert.AreEqual(MineralMiner.MiningGold, true);
        }
        
    }
}
