using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactTests
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
        public void IsDescentdantOfIndividual()
        {
            Client client = new Client();
            Assert.IsInstanceOfType(client, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteContractStartDate()
        {
            Client client = new Client();
            DateTime date = DateTime.Now;
            client.ContractStartDate = date;
            Assert.AreEqual(date.Date, client.ContractStartDate.Date);
        }

        [TestMethod]
        public void CanReadWriteContractValue()
        {
            Client client = new Client();
            client.CotnractValue = 45000m;
            Assert.AreEqual(45000m, client.CotnractValue);
        }
    }
}
