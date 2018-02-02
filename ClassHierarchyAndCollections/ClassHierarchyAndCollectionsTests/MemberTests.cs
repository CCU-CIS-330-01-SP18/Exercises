using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
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
        public void MemberDerivesFromIndividual()
        {
            Member m = new Member();
            Assert.IsInstanceOfType(m, typeof(Individual));
        }

        [TestMethod]
        public void MemberCanReadWriteMemberName()
        {
            Member m = new Member();
            m.MemberName = "Ryan";
            Assert.AreEqual("Ryan", m.MemberName);
        }

        [TestMethod]
        public void MemberCanReadWriteFeesDue()
        {
            Member m = new Member();
            m.FeesDue = true;
            Assert.AreEqual(true, m.FeesDue);
        }
    }
}
