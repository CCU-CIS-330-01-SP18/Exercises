using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;

namespace Week7ThreadingTests
{
    [TestClass]
    public class UnobtainiumTests
    {
        [TestMethod]
        public void CanGetUnobtainiumProperties()
        {
            Unobtainium g = new Unobtainium();
            Assert.AreEqual("Unobtainium", g.MineralName);
            Assert.AreEqual(15000, g.MiningTime);
            Assert.AreEqual(10000, g.BaseValue);
        }
    }
}
