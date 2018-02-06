using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    /// <summary>
    /// A compilation of tests that ensures that instances of Association can be created, their class derives from Organization,
    /// and that their properties can be written to and read.
    /// </summary>
    [TestClass]
    public class AssociationTest
    {
        /// <summary>
        /// A test that ensures that instances of Association can be created.
        /// </summary>
        [TestMethod]
        public void CanCreateAssociation()
        {
            var createdAssociation = new Association();
            Assert.IsNotNull(createdAssociation);
        }

        /// <summary>
        /// A test that ensures that the Association class derives from Organization.
        /// </summary>
        [TestMethod]
        public void AssociationDerivesFromOrganization()
        {
            var createdAssociation = new Association();
            Assert.IsInstanceOfType(createdAssociation, typeof(Organization));
        }

        /// <summary>
        /// A test that ensures the NextScheduledMeet property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteNextScheduledMeet()
        {
            var createdAssociation = new Association();
            var testDate = new DateTime(2018, 2, 14);
            createdAssociation.NextScheduledMeet = testDate;
            Assert.AreEqual(testDate, createdAssociation.NextScheduledMeet);
        }

        /// <summary>
        /// A test that ensures the Members property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteMembers()
        {
            var createdAssociation = new Association();
            List<Member> testList = new List<Member> { new Member() };
            createdAssociation.Members = testList;
            Assert.AreEqual(testList, createdAssociation.Members);
        }
    }
}
