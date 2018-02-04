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
    /// Tests the functionality of the School class.
    /// </summary>
    [TestClass]
    public class SchoolTest
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateSchool()
        {
            School s = new School();
            Assert.IsNotNull(s);
        }

        /// <summary>
        /// Tests if the class correctly inherets the first tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromDirectContent()
        {
            School s = new School();
            Assert.IsInstanceOfType(s, typeof(Organization));
        }

        /// <summary>
        /// Tests if the class correctly inherets the second tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromExtendedContent()
        {
            School s = new School();
            Assert.IsInstanceOfType(s, typeof(Contact));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void SchoolCanReadWriteMascot()
        {
            School s = new School();
            s.Mascot = "Cougar";
            Assert.AreEqual("Cougar", s.Mascot);
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void SchoolCanReadWriteColor()
        {
            School s = new School();
            s.Color = "Blue";
            Assert.AreEqual("Blue", s.Color);
        }
    }
}
