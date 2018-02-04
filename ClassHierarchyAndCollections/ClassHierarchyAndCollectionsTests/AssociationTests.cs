using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;
using System.Collections.Generic;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class AssociationTests
    {
        [TestMethod]
        public void CanInstantiateAssociation()
        {
            Association c = new Association();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void IsChildOfOrganization()
        {
            Association c = new Association();
            Assert.IsInstanceOfType(c, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteDues()
        {
            Association c = new Association();
            c.AnnualDues = 1200;
            Assert.AreEqual(1200, c.AnnualDues);
        }

        [TestMethod]
        public void CanReadWriteDueDate()
        {
            Association c = new Association();
            DateTime currentTime = DateTime.Now;
            c.DueDate = currentTime;
            Assert.AreEqual(currentTime, c.DueDate);
        }

        [TestMethod]
        public void CanReadWriteMembers()
        {
            Association c = new Association();
            List<Member> members = new List<Member>();
            members.Add(new Member());
            c.Members = members;
            Assert.AreEqual(members, c.Members);
        }
    }
}
