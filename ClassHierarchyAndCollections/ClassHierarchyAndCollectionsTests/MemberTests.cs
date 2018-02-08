using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            i.MemberBusiness = "Wendy's";
            Assert.AreEqual("Wendy's", i.MemberBusiness);
        }

        [TestMethod]
        public void CanGetSetDateJoined()
        {
            Member i = new Member();
            i.DateJoined = DateTime.Now;
            Assert.AreEqual(DateTime.Now, i.DateJoined);
        }

        [TestMethod]
        public void IsAnIndividual()
        {
            Member i = new Member();
            Assert.IsInstanceOfType(i, typeof(Individual));
        }
    }
}
