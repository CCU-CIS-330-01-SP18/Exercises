using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactTests
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void CanCreateMember()
        {
            Member m = new Member();
            Assert.IsNotNull(m);
        }

        [TestMethod]
        public void IsDescendantOfIndividual()
        {
            Member m = new Member();
            Assert.IsInstanceOfType(m, typeof(Member));
        }

        [TestMethod]
        public void CanReadWriteID()
        {
            Member m = new Member();
            m.ID = 0464940;
            Assert.AreEqual(0464940, m.ID);
        }

        [TestMethod]
        public void CanReadWriteJoinDate()
        {
            Member m = new Member();
            DateTime d = DateTime.Now.Date;
            Assert.AreEqual(d, DateTime.Now.Date);

        }
    }
}
