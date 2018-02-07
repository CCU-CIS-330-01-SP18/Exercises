using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierachyAndCollectionsTests
{
    [TestClass]
    public class AssociationTest
    {
       [TestMethod]
        public void CanCreateAssociation()
        {
            var createdAssociation = new Association();
            Assert.IsNotNull(createdAssociation);
        }

        [TestMethod]
        public void AssociationDerivesFromOrganization()
        {
            var createdAssociation = new Association();
            Assert.IsInstanceOfType(createdAssociation, typeof(Organization));
        }
      
        [TestMethod]
        public void CanReadWriteName()
        {
            var createdAssociation = new Association
            {
                AssociationName = "ChadderBox Inc."
            };

            Assert.AreEqual("ChadderBox Inc.", createdAssociation.AssociationName);
        }

        [TestMethod]
        public void nCanReadWriteLocation()
        {
            var createdAssociation = new Association
            {
                AssociationLocation = "Denver"
            };

            Assert.AreEqual("Denver", createdAssociation.AssociationLocation);
        }
    }
}

