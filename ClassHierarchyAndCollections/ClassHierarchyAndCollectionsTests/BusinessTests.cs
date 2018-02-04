using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;
using System.Collections.Generic;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void CanInstantiateBusiness()
        {
            Business c = new Business();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void IsChildOfOrganization()
        {
            Business c = new Business();
            Assert.IsInstanceOfType(c, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Business c = new Business();
            c.BusinessPhone = "303-963-3000";
            Assert.AreEqual("303-963-3000", c.BusinessPhone);
        }

        [TestMethod]
        public void CanReadWriteStockSymbol()
        {
            Business c = new Business();
            c.StockSymbol = "CCU";
            Assert.AreEqual("CCU", c.StockSymbol);
        }

        [TestMethod]
        public void CanReadWriteClients()
        {
            Business c = new Business();
            List<Client> clients = new List<Client>();
            clients.Add(new Client());
            c.Clients = clients;
            Assert.AreEqual(clients, c.Clients);
        }
    }
}
