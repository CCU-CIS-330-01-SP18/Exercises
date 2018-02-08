using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;



namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void CanMakeContact()
        {
            Contact c = new Contact();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void CanGetSetDisplayName()
        {
            Contact c = new Contact();
            c.DisplayName = "Knuckles";
            Assert.AreEqual("Knuckles", c.DisplayName);
        }

        [TestMethod]
        public void CanGetSetEmail()
        {
            Contact c = new Contact();
            c.EmailAddress = "swag@gmail.com";
            Assert.AreEqual("swag@gmail.com", c.EmailAddress);
        }
    }
}
