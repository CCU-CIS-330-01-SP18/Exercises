using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void CanMakeBusiness()
        {
            Business i = new Business();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void CanGetSetBusinessOwner()
        {
            Business i = new Business();
            i.BusinessOwner = "Steve Employments";
            Assert.AreEqual("Steve Employments", i.BusinessOwner);
        }

        [TestMethod]
        public void CanGetSetIsOwnedByDisney()
        {
            Business i = new Business();
            i.IsOwnedByDisney = true;
            Assert.AreEqual(true, i.IsOwnedByDisney);
        }

        [TestMethod]
        public void IsAContact()
        {
            Business i = new Business();
            Assert.IsInstanceOfType(i, typeof(Organization));
        }
    }
}
