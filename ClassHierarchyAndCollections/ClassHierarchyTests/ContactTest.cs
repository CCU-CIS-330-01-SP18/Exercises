using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyTests
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void CanCreateContact()
        {
            Contact c = new Contact();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void ContentDerivesFromContent()
        {
            Contact c = new Contact();
            Assert.IsInstanceOfType(c, typeof(object));
        }

        [TestMethod]
        public void ContactCanReadWriteDisplayName()
        {
            Contact c = new Contact();
            c.DisplayName = "Dylan";
            Assert.AreEqual("Dylan", c.DisplayName);
        }

        [TestMethod]
        public void ContactCanReadWriteLegalName()
        {
            Contact c = new Contact();
            c.LegalName = "Dylan";
            Assert.AreEqual("Dylan", c.LegalName);
        }
    }
}
