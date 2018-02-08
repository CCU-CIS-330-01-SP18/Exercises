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
            Business business = new Business();
            Assert.IsNotNull(business);
        }

        [TestMethod]
        public void BusinessInheritsOrganization()
        {
            Business business = new Business();
            Assert.IsInstanceOfType(business, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteBusinessName()
        {
            Business business = new Business();
            business.BusinessName = "Facebook";
            Assert.AreEqual("Facebook", business.BusinessName);
        }

        [TestMethod]
        public void CanReadWriteBusinessStockPrice()
        {
            Business business = new Business();
            business.BusinessStockPrice = 163.47f;
            Assert.AreEqual(163.47f, business.BusinessStockPrice);
        }
    }
}
