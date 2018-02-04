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
    /// Tests the functionality of the Business class.
    /// </summary>
    [TestClass]
    public class BusinessTest
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateBusiness()
        {
            Business b = new Business();
            Assert.IsNotNull(b);
        }

        /// <summary>
        /// Tests if the class correctly inherets the first tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromDirectContent()
        {
            Business b = new Business();
            Assert.IsInstanceOfType(b, typeof(Organization));
        }

        /// <summary>
        /// Tests if the class correctly inherets the second tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromExtendedContent()
        {
            Business b = new Business();
            Assert.IsInstanceOfType(b, typeof(Contact));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void BusinessCanReadWriteMissionStatement()
        {
            Business b = new Business();
            b.MissionStatement = "We promote good things";
            Assert.AreEqual("We promote good things", b.MissionStatement);
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void BusinessCanReadWriteMembers()
        {
            Business b = new Business();
            b.Members = new List<Member>();
            CollectionAssert.AreEqual(new List<Member>(), b.Members);
        }
    }
}
