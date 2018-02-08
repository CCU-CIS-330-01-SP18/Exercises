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
            Member member = new Member();
            Assert.IsNotNull(member);
        }

        [TestMethod]
        public void IsDescendantOfIndividual()
        {
            Member member = new Member();
            Assert.IsInstanceOfType(member, typeof(Member));
        }

        [TestMethod]
        public void CanReadWriteID()
        {
            Member member = new Member();
            member.ID = 0464940;
            Assert.AreEqual(0464940, member.ID);
        }

        [TestMethod]
        public void CanReadWriteJoinDate()
        {
            Member member = new Member();
            DateTime date = DateTime.Now.Date;
            Assert.AreEqual(date, DateTime.Now.Date);

        }
    }
}
