using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CanInstantiateClient()
        {
            Client c = new Client();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void IsChildOfIndividual()
        {
            Client c = new Client();
            Assert.IsInstanceOfType(c, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteClientID()
        {
            Client c = new Client();
            c.ClientID = 748596;
            Assert.AreEqual(748596, c.ClientID);
        }

        [TestMethod]
        public void CanReadWritePriority()
        {
            Client c = new Client();
            c.Priority = ClientPriority.Low;
            Assert.AreEqual(ClientPriority.Low, c.Priority);
        }
    }
}
