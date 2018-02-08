using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ClassHierarchyAndCollections;

namespace ContactTests
{
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void CanCreateBusiness()
        {
            Business business = new Business();
            Assert.IsNotNull(business);
        }

        [TestMethod]
        public void IsDescendantOfOrganization()
        {
            Business business = new Business();
            Assert.IsInstanceOfType(business, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteClients()
        {
            Business business = new Business();
            business.Clients = new List<Client>();
            Client client = new Client();
            business.Clients.Add(client);
            Assert.AreEqual(client, business.Clients[0]);
        }

        [TestMethod]
        public void CanReadWritePrimaryService()
        {
            Business business = new Business();
            business.PrimaryService = "Distributes News Papers";
            Assert.AreEqual("Distributes News Papers", business.PrimaryService);
        }

        [TestMethod]
        public void CanUseInterface()
        {
            Business business = new Business();
            business.Clients = new List<Client>();
            Client client1 = new Client();
            client1.DisplayName = "Bob";
            Client client2 = new Client();
            client2.DisplayName = "Joe";
            Client client3 = new Client();
            client3.DisplayName = "Sue";
            business.Clients.Add(client1);
            business.Clients.Add(client2);
            business.Clients.Add(client3);

            business.ReadList();
        }
    }
}
