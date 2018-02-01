using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    /// <summary>
    /// A compilation of tests that ensures that instances of Member can be created, their class derives from Individual,
    /// and that their properties can be written to and read.
    /// </summary>
    [TestClass]
    public class MemberTest
    {
        /// <summary>
        /// A test that ensures that instances of Member can be created.
        /// </summary>
        [TestMethod]
        public void CanCreateMember()
        {
            var createdMember = new Member();
            Assert.IsNotNull(createdMember);
        }

        /// <summary>
        /// A test that ensures that the Member class derives from Individual.
        /// </summary>
        [TestMethod]
        public void MemberDerivesFromIndividual()
        {
            var createdMember = new Member();
            Assert.IsInstanceOfType(createdMember, typeof(Individual));
        }

        /// <summary>
        /// A test that ensures the ContributedHours property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteContributedHours()
        {
            var createdMember = new Member();
            createdMember.ContributedHours = 3;
            Assert.AreEqual(3, createdMember.ContributedHours);
        }

        /// <summary>
        /// A test that ensures the RoleName property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteRoleName()
        {
            var createdMember = new Member();
            createdMember.RoleName = "Test";
            Assert.AreEqual("Test", createdMember.RoleName);
        }
    }
}
