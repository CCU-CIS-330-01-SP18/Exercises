using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CanCreateClient()
        {
            Client client = new Client();
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void ClientInheritsIndividual()
        {
            Client client = new Client();
            Assert.IsInstanceOfType(client, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteClientService()
        {
            Client client = new Client();
            client.ClientService = "Software Installation";
            Assert.AreEqual("Software Installation", client.ClientService);
        }

        [TestMethod]
        public void CanReadWriteLengthOfBeingClient()
        {
            Client client = new Client();
            client.LengthOfBeingClient = 10;
            Assert.AreEqual(10, client.LengthOfBeingClient);
        }
    }
}
