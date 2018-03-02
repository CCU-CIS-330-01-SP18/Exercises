using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;

namespace Week7ThreadingTests
{
    [TestClass]
    public class GoldTests
    {
        [TestMethod]
        public void CanGetGoldProperties()
        {
            Gold g = new Gold();
            Assert.AreEqual("Gold", g.MineralName);
            Assert.AreEqual(10000, g.MiningTime);
            Assert.AreEqual(10, g.BaseValue);
        }
    }
}
