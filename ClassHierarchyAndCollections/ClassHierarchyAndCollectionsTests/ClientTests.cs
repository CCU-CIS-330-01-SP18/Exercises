using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CanMakeClient()
        {
            Client i = new Client();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void CanGetSetClientBusiness()
        {
            Client i = new Client();
            i.ClientBusiness = "Wendy's";
            Assert.AreEqual("Wendy's", i.ClientBusiness);
        }

        [TestMethod]
        public void CanGetSetClientCreditStanding()
        {
            Client i = new Client();
            i.CreditStanding = "Poor";
            Assert.AreEqual("Poor", i.CreditStanding);
        }

        [TestMethod]
        public void IsAnIndividual()
        {
            Client i = new Client();
            Assert.IsInstanceOfType(i, typeof(Individual));
        }
    }
}
