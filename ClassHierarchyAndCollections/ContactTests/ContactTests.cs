using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ContactTests
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
        public void CanReadWriteDisplayName()
        {
            Contact c = new Contact();
            c.DisplayName = "Dean";
            Assert.AreEqual("Dean", c.DisplayName);
        }
        [TestMethod]
        public void CanReadWriteLegalName()
        {
            Contact c = new Contact();
            c.LegalName = "test";
            Assert.AreEqual("test", c.LegalName);
        }
    }
}
