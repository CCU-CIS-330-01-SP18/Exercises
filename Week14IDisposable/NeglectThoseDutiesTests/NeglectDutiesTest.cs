using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeglectThoseDuties;

namespace NeglectThoseDutiesTests
{
    [TestClass]
    public class NeglectDutiesTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string duties = "The duty to accomplish this assignment well.";
            bool result = NeglectDuties.NeglectMyDuties(duties);
            Assert.AreEqual(result, true);
        }
    }
}
