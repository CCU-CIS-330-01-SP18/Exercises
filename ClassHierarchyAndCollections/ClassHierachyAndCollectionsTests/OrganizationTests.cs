using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierachyAndCollectionsTests
{
    [TestClass]
    public class OrganizationTests
    {
        [TestMethod]
        public void CanCreateOrganization()
        {
            var createdOrganization = new Organization();
            Assert.IsNotNull(createdOrganization);
        }

        [TestMethod]
        public void ClientDerivesFromContact()
        {
            var createdOrganization = new Organization();
            Assert.IsInstanceOfType(createdOrganization, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteOrganizationAddress()
        {
            var createdOrganization = new Organization
            {
                OrganizationAddress = "1234 Fake St, Denver CO"
            };

            Assert.AreEqual("1234 Fake St, Denver CO", createdOrganization.OrganizationAddress);
        }

        [TestMethod]
        public void CanReadWriteOrganizationNumberNumber()
        {
            var createdOrganization = new Organization
            {
                OrganizationNumber = 123-123-1234
            };

            Assert.AreEqual(123-123-1234, createdOrganization.OrganizationNumber);
        }
    }
}
