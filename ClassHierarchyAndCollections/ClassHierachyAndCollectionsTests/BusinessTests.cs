using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierachyAndCollectionsTests
{
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void CanCreateBusiness()
        {
            var createdBusiness = new Business();
            Assert.IsNotNull(createdBusiness);
        }

        [TestMethod]
        public void BusinessDerivesFromOrganization()
        {
            var createdBusiness = new Business();
            Assert.IsInstanceOfType(createdBusiness, typeof(Organization));
        }

        [TestMethod]
        public void BusinessDerivesFromILocatable()
        {
            var createdBusiness = new Business();
            Assert.IsInstanceOfType(createdBusiness, typeof(ILocatable));
        }

        [TestMethod]
        public void CanReadWriteClients()
        {
            var createdBusiness = new Business
            {
                Clients = "Example Clients"
            };

            Assert.AreEqual("Example Clients", createdBusiness.Clients);
        }

        [TestMethod]
        public void CanReadWriteEmployees()
        {
            var createdBusiness = new Business
            {
                Employees = "Example Employees"
            };

            Assert.AreEqual("Example Employees", createdBusiness.Employees);
        }

        [TestMethod]
        public void CanReadWriteLocation()
        {
            string myLocation = "Denver";
            var location = new Business();
            Assert.AreEqual("Denver", location.GetLocation(myLocation));
        }


    }
}
