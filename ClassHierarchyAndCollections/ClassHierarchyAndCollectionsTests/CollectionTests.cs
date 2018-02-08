using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;
using System.Collections.Generic;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        public void AllItemsAreInstancesOfClient()
        {
            Business bus = new Business();
            List<Client> clientList = new List<Client>();

            CollectionAssert.AllItemsAreInstancesOfType(clientList, typeof(Client));
        }

        [TestMethod]
        public void AllClientsAreUnique()
        {
            List<Client> clientList = new List<Client>();
            clientList.Add(new Client { ClientName = "XLedger" });
            clientList.Add(new Client { ClientName = "Denver Health" });
            clientList.Add(new Client { ClientName = "Coca Cola}" });

            CollectionAssert.AllItemsAreUnique(clientList);
        }
    }
}
