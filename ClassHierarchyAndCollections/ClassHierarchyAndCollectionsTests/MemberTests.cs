using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void CanInstantiateMember()
        {
            Member c = new Member();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void IsChildOfIndividual()
        {
            Member c = new Member();
            Assert.IsInstanceOfType(c, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteMemberID()
        {
            Member c = new Member();
            c.MemberID = 142536;
            Assert.AreEqual(142536, c.MemberID);
        }

        [TestMethod]
        public void CanReadWriteJoinDate()
        {
            Member c = new Member();
            DateTime currentTime = DateTime.Now;
            c.JoinDate = currentTime;
            Assert.AreEqual(currentTime, c.JoinDate);
        }
    }
}