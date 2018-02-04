using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchyAndCollections;

namespace ClassHierarchyTests
{
    /// <summary>
    /// Tests the functionality of the Organization class.
    /// </summary>
    [TestClass]
    public class OrganizationTest
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateOrganization()
        {
            Organization o = new Organization();
            Assert.IsNotNull(o);
        }

        /// <summary>
        /// Tests if the class correctly inherets the specified hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromContent()
        {
            Organization o = new Organization();
            Assert.IsInstanceOfType(o, typeof(Contact));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void OrganizationCanReadWriteAddress()
        {
            Organization o = new Organization();
            o.Address = "My Address";
            Assert.AreEqual("My Address", o.Address);
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void OrganizationCanReadWriteZipCode()
        {
            Organization o = new Organization();
            o.ZipCode = 80005;
            Assert.AreEqual(80005, o.ZipCode);
        }
    }
}
