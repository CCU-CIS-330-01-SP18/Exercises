using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
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
        public void MemberInheritsIndividual()
        {
            Member member = new Member();
            Assert.IsInstanceOfType(member, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteMemberID()
        {
            Member member = new Member();
            member.MemberID = 01245;
            Assert.AreEqual(01245, member.MemberID);
        }

        [TestMethod]
        public void CanReadWriteMemberName()
        {
            Member member = new Member();
            member.MemberName = "John";
            Assert.AreEqual("John", member.MemberName);
        }
    }
}
