using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierachyAndCollectionsTests
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void CanCreateContact()
        {
            var createdContact = new Contact();
            Assert.IsNotNull(createdContact);
        }

        [TestMethod]
        public void ClientDerivesFromItself()
        {
            var createdContact = new Contact();
            Assert.IsInstanceOfType(createdContact, typeof(Object));
        }

        [TestMethod]
        public void CanReadWriteFullName()
        {
            var createdContact = new Contact
            {
                FullName = "Chad Parsons"
            };

            Assert.AreEqual("Chad Parsons", createdContact.FullName);
        }

        [TestMethod]
        public void CanReadWriteContactNumber()
        {
            var createdContact = new Contact
            {
                ContactNumber = 111-222-1234
            };

            Assert.AreEqual(111-222-1234, createdContact.ContactNumber);
        }
    }
}
