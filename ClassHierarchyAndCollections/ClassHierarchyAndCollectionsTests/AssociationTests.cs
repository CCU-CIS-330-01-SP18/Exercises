using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class AssociationTests
    {
        [TestMethod]
        public void CanMakeAssociation()
        {
            Association i = new Association();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void CanGetSetAnnualDues()
        {
            Association i = new Association();
            i.AnnualDues = "$100";
            Assert.AreEqual("$100", i.AnnualDues);
        }

        [TestMethod]
        public void CanGetSetHeadquartersLocation()
        {
            Association i = new Association();
            i.HeadquartersLocation = "Chad's Basement";
            Assert.AreEqual("Chad's Basement", i.HeadquartersLocation);
        }

        [TestMethod]
        public void IsAContact()
        {
            Association i = new Association();
            Assert.IsInstanceOfType(i, typeof(Organization));
        }
    }
}
