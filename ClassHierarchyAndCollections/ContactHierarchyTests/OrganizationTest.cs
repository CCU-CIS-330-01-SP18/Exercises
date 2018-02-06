using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    /// <summary>
    /// A compilation of tests that ensures that instances of Organization can be created, their class derives from Contact,
    /// and that their properties can be written to and read.
    /// </summary>
    [TestClass]
    public class OrganizationTest
    {
        /// <summary>
        /// A test that ensures that instances of Organization can be created.
        /// </summary>
        [TestMethod]
        public void CanCreateOrganization()
        {
            var createdOrganization = new Organization();
            Assert.IsNotNull(createdOrganization);
        }

        /// <summary>
        /// A test that ensures that the Organization class derives from Contact.
        /// </summary>
        [TestMethod]
        public void OrganizationDerivesFromContact()
        {
            var createdOrganization = new Organization();
            Assert.IsInstanceOfType(createdOrganization, typeof(Contact));
        }

        /// <summary>
        /// A test that ensures the Province property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteProvince()
        {
            var createdOrganization = new Organization();
            createdOrganization.Province = "Test";
            Assert.AreEqual("Test", createdOrganization.Province);
        }

        /// <summary>
        /// A test that ensures the FormationDate property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteFormationDate()
        {
            var createdOrganization = new Organization();
            var testDate = new DateTime(2018, 2, 14);
            createdOrganization.FormationDate = testDate;
            Assert.AreEqual(testDate, createdOrganization.FormationDate);
        }
    }
}
