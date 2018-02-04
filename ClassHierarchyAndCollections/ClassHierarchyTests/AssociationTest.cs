using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyTests
{
    /// <summary>
    /// Tests the functionality of the Association class.
    /// </summary>
    [TestClass]
    public class AssociationTest
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateAssociation()
        {
            Association a = new Association();
            Assert.IsNotNull(a);
        }

        /// <summary>
        /// Tests if the class correctly inherets the first tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromDirectContent()
        {
            Association a = new Association();
            Assert.IsInstanceOfType(a, typeof(Organization));
        }

        /// <summary>
        /// Tests if the class correctly inherets the second tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromExtendedContent()
        {
            Association a = new Association();
            Assert.IsInstanceOfType(a, typeof(Contact));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void AssociationCanReadWriteCity()
        {
            Association a = new Association();
            a.City = "Arvada";
            Assert.AreEqual("Arvada", a.City);
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void AssociationCanReadWriteState()
        {
            Association a = new Association();
            a.State = "Colorado";
            Assert.AreEqual("Colorado", a.State);
        }
    }
}
