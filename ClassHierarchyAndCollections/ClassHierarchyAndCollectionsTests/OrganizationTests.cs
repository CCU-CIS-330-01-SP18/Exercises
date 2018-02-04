using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class OrganizationTests
    {
        [TestMethod]
        public void CanInstantiateOrganization()
        {
            Organization c = new Organization();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void IsChildOfContact()
        {
            Organization c = new Organization();
            Assert.IsInstanceOfType(c, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteAddress()
        {
            Organization c = new Organization();
            c.PhysicalAddress = "8787 W. Alameda Ave.";
            Assert.AreEqual("8787 W. Alameda Ave.", c.PhysicalAddress);
        }

        [TestMethod]
        public void CanReadWriteDate()
        {
            Organization c = new Organization();
            DateTime currentTime = DateTime.Now;
            c.FormationDate = currentTime;
            Assert.AreEqual(currentTime, c.FormationDate);
        }
    }
}
