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
            Business b = new Business();
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void IsDescendantOfOrganization()
        {
            Business b = new Business();
            Assert.IsInstanceOfType(b, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteClients()
        {
            Business b = new Business();
            b.Clients = new List<Client>();
            Client c = new Client();
            b.Clients.Add(c);
            Assert.AreEqual(c, b.Clients[0]);
        }

        [TestMethod]
        public void CanReadWritePrimaryService()
        {
            Business b = new Business();
            b.PrimaryService = "Distributes News Papers";
            Assert.AreEqual("Distributes News Papers", b.PrimaryService);
        }
    }
}
