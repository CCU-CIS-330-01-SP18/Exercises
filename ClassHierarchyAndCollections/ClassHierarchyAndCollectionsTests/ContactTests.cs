using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void CanInstantiateContact()
        {
            Contact c = new Contact();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Contact c = new Contact();
            c.DisplayName = "Name";
            Assert.AreEqual("Name", c.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Contact c = new Contact();
            c.EmailAddress = "test@site.com";
            Assert.AreEqual("test@site.com", c.EmailAddress);
        }
    }
}
