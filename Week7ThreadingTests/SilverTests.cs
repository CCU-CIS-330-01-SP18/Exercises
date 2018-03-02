using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;

namespace Week7ThreadingTests
{
    [TestClass]
    public class SilverTests
    {
        [TestMethod]
        public void CanGetSilverProperties()
        {
            Silver g = new Silver();
            Assert.AreEqual("Silver", g.MineralName);
            Assert.AreEqual(5000, g.MiningTime);
            Assert.AreEqual(5, g.BaseValue);
        }
    }
}
