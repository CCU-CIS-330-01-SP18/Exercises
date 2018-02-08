using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class AssociationTests
    {
        [TestMethod]
        public void CanCreateAssociation()
        {
            Association a = new Association();
            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void AssociationDerivesFromOrganization()
        {
            Association a = new Association();
            Assert.IsInstanceOfType(a, typeof(Organization));
        }

        [TestMethod]
        public void AssociationCanReadWriteAssociationName()
        {
            Association a = new Association();
            a.AssociationName = "example association";
            Assert.AreEqual("example association", a.AssociationName);
        }

        [TestMethod]
        public void AssociationCanReadWriteAssociationFee()
        {
            Association a = new Association();
            a.AssociationFee = 25;
            Assert.AreEqual(25, a.AssociationFee);
        }
    }
}
