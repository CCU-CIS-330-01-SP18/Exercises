using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void CanCreateContact()
        {
            Contact contact = new Contact();
            Assert.IsNotNull(contact);
        }

        [TestMethod]
        public void ContactDerivesFromObject()
        {
            Contact contact = new Contact();
            Assert.IsInstanceOfType(contact, typeof(Object));
        }

        [TestMethod]
        public void CanReadWriteDisplayName()
        {
            Contact contact = new Contact();
            contact.DisplayName = "Justin";
            Assert.AreEqual("Justin", contact.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteLegalName()
        {
            Contact contact = new Contact();
            contact.LegalName = "Horak";
            Assert.AreEqual("Horak", contact.LegalName);
        }
    }
}
