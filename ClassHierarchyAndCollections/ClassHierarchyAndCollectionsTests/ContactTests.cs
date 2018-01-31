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
            Contact c = new Contact();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void ContactDerivesFromObject()
        {
            Contact c = new Contact();
            Assert.IsInstanceOfType(c, typeof(Object));
        }

        [TestMethod]
        public void ContactCanReadWriteDisplayName()
        {
            Contact c = new Contact();
            c.DisplayName = "Matt";
            Assert.AreEqual("Matt", c.DisplayName);
        }

        [TestMethod]
        public void ContactCanReadWriteLegalName()
        {
            Contact c = new Contact();
            c.LegalName = "Matt";
            Assert.AreEqual("Matt", c.LegalName);
        }
    }
}
