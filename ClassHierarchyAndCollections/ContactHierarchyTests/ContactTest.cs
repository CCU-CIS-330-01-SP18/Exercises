using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    /// <summary>
    /// A compilation of tests that ensures that instances of Contact can be created, their class derives from Object,
    /// and that their properties can be written to and read.
    /// </summary>
    [TestClass]
    public class ContactTest
    {
        /// <summary>
        /// A test that ensures that instances of Contact can be created.
        /// </summary>
        [TestMethod]
        public void CanCreateContact()
        {
            var createdContact = new Contact();
            Assert.IsNotNull(createdContact);
        }

        /// <summary>
        /// A test that ensures that the Contact class derives from Object.
        /// </summary>
        [TestMethod]
        public void ContactDerivesFromObject()
        {
            var createdContact = new Contact();
            Assert.IsInstanceOfType(createdContact, typeof(Object));
        }

        /// <summary>
        /// A test that ensures the DisplayName property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteDisplayName()
        {
            var createdContact = new Contact();
            createdContact.DisplayName = "Test";
            Assert.AreEqual("Test", createdContact.DisplayName);
        }

        /// <summary>
        /// A test that ensures the LegalName property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteLegalName()
        {
            var createdContact = new Contact();
            createdContact.LegalName = "Test";
            Assert.AreEqual("Test", createdContact.LegalName);
        }
    }
}
