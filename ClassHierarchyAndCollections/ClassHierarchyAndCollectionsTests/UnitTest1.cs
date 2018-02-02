using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanCreateClient()
        {
            Client c = new Client();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void ClientDerivesFromIndividual()
        {
            Client c = new Client();
            Assert.IsInstanceOfType(c, typeof(Individual));
        }

        [TestMethod]
        public void ClientCanReadWriteClientName()
        {
            Client c = new Client();
            c.ClientName = "Sodexo";
            Assert.AreEqual("Sodexo", c.ClientName);
        }

        [TestMethod]
        public void ClientCanReadWriteClientIndustry()
        {
            Client c = new Client();
            c.ClientIndustry = "Food Services";
            Assert.AreEqual("Food Services", c.ClientIndustry);
        }
    }
}
