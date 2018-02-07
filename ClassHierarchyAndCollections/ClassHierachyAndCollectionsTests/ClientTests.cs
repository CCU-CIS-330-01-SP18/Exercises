using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierachyAndCollectionsTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CanCreateClient()
        {
            var createdClient = new Client();
            Assert.IsNotNull(createdClient);
        }

        [TestMethod]
        public void ClientDerivesFromIndividual()
        {
            var createdClient = new Client();
            Assert.IsInstanceOfType(createdClient, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteUserID()
        {
            var createdClient = new Client
            {
                UserID = "12345"
            };

            Assert.AreEqual("12345", createdClient.UserID);
        }

        [TestMethod]
        public void CanReadWriteUserName()
        {
            var createdClient = new Client
            {
                UserName = "Example Name"
            };

            Assert.AreEqual("Example Name", createdClient.UserName);
        }
    }
}
