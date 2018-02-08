using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class OrganizationTests
    {
        [TestMethod]
        public void CanCreateOrganization()
        {
            Organization organization = new Organization();
            Assert.IsNotNull(organization);
        }

        [TestMethod]
        public void OrganizationInheritsContact()
        {
            Organization organization = new Organization();
            Assert.IsInstanceOfType(organization, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteOrganizationName()
        {
            Organization organization = new Organization();
            organization.OrganizationName = "Apple";
            Assert.AreEqual("Apple", organization.OrganizationName);
        }

        [TestMethod]
        public void CanReadWriteOrganizationAddress()
        {
            Organization organization = new Organization();
            organization.OrganizaitonAddress = "Cupertino, CA";
            Assert.AreEqual("Cupertino, CA", organization.OrganizaitonAddress);
        }
    }
}
