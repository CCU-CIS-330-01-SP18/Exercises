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
        public void CanGetSetFormationDate()
        {
            Business i = new Business();
            i.FormationDate = DateTime.Now;
            Assert.AreEqual(DateTime.Now, i.FormationDate);
        }

        [TestMethod]
        public void CanGetSetBusinessName()
        {
            Business i = new Business();
            i.BusinessName = "PETA";
            Assert.AreEqual("PETA", i.BusinessName);
        }

        [TestMethod]
        public void IsAContact()
        {
            Business i = new Business();
            Assert.IsInstanceOfType(i, typeof(Contact));
        }
    }
}
