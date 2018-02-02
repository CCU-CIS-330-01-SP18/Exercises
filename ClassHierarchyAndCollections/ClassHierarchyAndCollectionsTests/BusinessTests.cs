using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
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
        public void BusinessDerivesFromOrganization()
        {
            Business b = new Business();
            Assert.IsInstanceOfType(b, typeof(Organization));
        }

        [TestMethod]
        public void BusinessCanReadWriteBusinessEntity()
        {
            Business b = new Business();
            b.BusinessEntity = "LLC";
            Assert.AreEqual("LLC", b.BusinessEntity);
        }

        [TestMethod]
        public void BusinessCanReadWriteSales()
        {
            Business b = new Business();
            b.Sales = 100000;
            Assert.AreEqual(100000, b.Sales);
        }
    }
}
