using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;

namespace Week7ThreadingTests
{
    [TestClass]
    public class MineralTests
    {
        [TestMethod]
        public void CanGetSetMineralProperties()
        {
            Mineral salt = new Mineral("Salt",1000,1);
            Assert.AreEqual("Salt", salt.MineralName);
            Assert.AreEqual(1000, salt.MiningTime);
            Assert.AreEqual(1, salt.BaseValue);
        }
    }
}
