using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class AssociationTests
    {
        [TestMethod]
        public void CanCreateAssociation()
        {
            Association association = new Association();
            Assert.IsNotNull(association);
        }

        [TestMethod]
        public void AssociationInheritsOrganization()
        {
            Association association  = new Association();
            Assert.IsInstanceOfType(association, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteAssociationName()
        {
            Association association = new Association();
            association.AssociationName = "Apple";
            Assert.AreEqual("Apple", association.AssociationName);
        }

        [TestMethod]
        public void CanReadWriteMemberCount()
        {
            Association association = new Association();
            association.MemberCount = 500;
            Assert.AreEqual(500, association.MemberCount);
        }
    }
}
