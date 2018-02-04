using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyTests
{
    /// <summary>
    /// Tests the functionality of the Contact class.
    /// </summary>
    [TestClass]
    public class ContactTest
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateContact()
        {
            Contact c = new Contact();
            Assert.IsNotNull(c);
        }

        /// <summary>
        /// Tests if the class correctly inherets the specified hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromContent()
        {
            Contact c = new Contact();
            Assert.IsInstanceOfType(c, typeof(object));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void ContactCanReadWriteDisplayName()
        {
            Contact c = new Contact();
            c.DisplayName = "Dylan";
            Assert.AreEqual("Dylan", c.DisplayName);
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void ContactCanReadWriteLegalName()
        {
            Contact c = new Contact();
            c.LegalName = "Dylan";
            Assert.AreEqual("Dylan", c.LegalName);
        }
    }
}
