using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactTests
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
        public void OrganizationDerivesFromContact()
        {
            Organization organization = new Organization();
            Assert.IsInstanceOfType(organization, typeof(Contact));
        }
        [TestMethod]
        public void CanReadWriteAddress()
        {
            Organization organization = new Organization();
            organization.HeadQuartersAddress = "123 Test Street";
            Assert.AreEqual("123 Test Street",organization.HeadQuartersAddress);
        }
        [TestMethod]
        public void CanReadWriteIsForProfit()
        {
            Organization organization = new Organization();
            organization.IsForProfit = false;
            Assert.AreEqual(false, organization.IsForProfit);
        }
    }
}

