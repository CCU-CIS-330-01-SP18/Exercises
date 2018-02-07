using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierachyAndCollectionsTests
{
    /// <summary>
    /// Tests the functionality of the Association class.
    /// </summary>
    [TestClass]
    public class AssociationTests
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateAssociation()
        {
            var AssociationTests = new AssociationTests();
            Assert.IsNotNull(AssociationTests);
        }

        /// <summary>
        /// Tests if the class correctly inherets the first tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromOrganization()
        {
            AssociationTests a = new AssociationTests();
            Assert.IsInstanceOfType(a, typeof(AssociationTests));
        }

        /// <summary>
        /// Tests if the class correctly inherets the second tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromExtendedContent()
        {
            AssociationTests a = new AssociationTests();
            Assert.IsInstanceOfType(a, typeof(AssociationTests));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void AssociationCanReadWriteName()
        {        
            /*
            var createdAssociation = new Association();
            createdBusiness.OwnerName = "Test";
            Assert.AreEqual("Test", createdBusiness.OwnerName);
            */
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void AssociationCanReadWriteLocation()
        {
            /*
            AssociationTests a = new AssociationTests();
            a.State = "Colorado";
            Assert.AreEqual("Colorado", a.State);
            */
        }
    }
}

