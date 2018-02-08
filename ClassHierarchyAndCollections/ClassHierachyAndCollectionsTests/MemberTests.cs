using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierachyAndCollectionsTests
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void CanCreateMember()
        {
            var createdMember = new Member();
            Assert.IsNotNull(createdMember);
        }

        [TestMethod]
        public void MemberDerivesFromIndividual()
        {
            var createdMember = new Member();
            Assert.IsInstanceOfType(createdMember, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteMemberID()
        {
            var createdMember = new Member
            {
                MemberID = 123456789
            };

            Assert.AreEqual(123456789, createdMember.MemberID);
        }

        [TestMethod]
        public void CanReadWriteJoinDate()
        {
            
            var createdDate = new DateTime(2018, 2, 7);
            var createdMember = new Member
            {
                JoinDate = createdDate
            };

            Assert.AreEqual(createdDate, createdMember.JoinDate);
        }
    }
}
