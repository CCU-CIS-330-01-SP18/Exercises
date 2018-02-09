using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class OrganizationTests
    {
        [TestMethod]
        public void CanMakeOrganization()
        {
            Organization i = new Organization();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void CanGetSetFormationDate()
        {
            Organization i = new Organization();
            i.FormationDate = "June 1 1996";
            Assert.AreEqual("June 1 1996", i.FormationDate);
        }

        [TestMethod]
        public void CanGetSetOrganizationName()
        {
            Organization i = new Organization();
            i.OrganizationName = "PETA";
            Assert.AreEqual("PETA", i.OrganizationName);
        }

        [TestMethod]
        public void IsAContact()
        {
            Organization i = new Organization();
            Assert.IsInstanceOfType(i, typeof(Contact));
        }
    }
}

