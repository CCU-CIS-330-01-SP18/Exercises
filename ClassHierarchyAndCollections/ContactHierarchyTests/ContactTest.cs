using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void CanCreateContact()
        {
            var createdContact = new Contact();
            Assert.IsNotNull(createdContact);
        }

        [TestMethod]
        public void ContactDerivesFromObject()
        {
            var createdContact = new Contact();
            Assert.IsInstanceOfType(createdContact, typeof(Object));
        }

        [TestMethod]
        public void CanReadWriteDisplayName()
        {
            var createdContact = new Contact();
            createdContact.DisplayName = "Test";
            Assert.AreEqual("Test", createdContact.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteLegalName()
        {
            var createdContact = new Contact();
            createdContact.LegalName = "Test";
            Assert.AreEqual("Test", createdContact.LegalName);
        }
    }
}
