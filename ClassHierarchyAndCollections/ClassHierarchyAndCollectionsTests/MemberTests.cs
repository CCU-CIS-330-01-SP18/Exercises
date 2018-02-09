using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void CanMakeMember()
        {
            Member i = new Member();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void CanGetSetLevelOfMembership()
        {
            Member i = new Member();
            i.LevelOfMembership = "Elite";
            Assert.AreEqual("Elite", i.LevelOfMembership);
        }

        [TestMethod]
        public void CanGetSetDateJoined()
        {
            Member i = new Member();
            i.DateJoined = "July 4 1776";
            Assert.AreEqual("July 4 1776", i.DateJoined);
        }

        [TestMethod]
        public void IsAnIndividual()
        {
            Member i = new Member();
            Assert.IsInstanceOfType(i, typeof(Individual));
        }
    }
}
