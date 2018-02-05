using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassHierarchyAndCollectionsTests
{
    /// <summary>
    /// Defines unit tests for the <see cref="Contact"/> class.
    /// </summary>
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
        public void CanReadWriteName()
        {
            Contact contact = new Contact()
            {
                DisplayName = "Joe Cool"
            };
            Assert.AreEqual("Joe Cool", contact.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Contact contact = new Contact()
            {
                EmailAddress = "jcool@ccu.edu"
            };
            Assert.AreEqual("jcool@ccu.edu", contact.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Contact contact = new Contact()
            {
                PhoneNumber = "9705551234"
            };
            Assert.AreEqual("9705551234", contact.PhoneNumber);
        }
    }
}
