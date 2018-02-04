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
    /// Tests the functionality of the Member class.
    /// </summary>
    [TestClass]
    public class MemberTest
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateMember()
        {
            Member m = new Member();
            Assert.IsNotNull(m);
        }

        /// <summary>
        /// Tests if the class correctly inherets the first tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromDirectContent()
        {
            Member m = new Member();
            Assert.IsInstanceOfType(m, typeof(Individual));
        }

        /// <summary>
        /// Tests if the class correctly inherets the second tier in the hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromExtendedContent()
        {
            Member m = new Member();
            Assert.IsInstanceOfType(m, typeof(Contact));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void MemberCanReadWriteRank()
        {
            Member m = new Member();
            m.Rank = 10;
            Assert.AreEqual(10, m.Rank);
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void MemberCanReadWritePositionTitle()
        {
            Member m = new Member();
            m.PositionTitle = "Jr. Developer";
            Assert.AreEqual("Jr. Developer", m.PositionTitle);
        }
    }
}
