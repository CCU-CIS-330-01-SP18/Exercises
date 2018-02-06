using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    /// <summary>
    /// A compilation of tests that ensures that instances of School can be created, their class derives from Organization,
    /// and that their properties can be written to and read.
    /// </summary>
    [TestClass]
    public class SchoolTest
    {
        /// <summary>
        /// A test that ensures that instances of School can be created.
        /// </summary>
        [TestMethod]
        public void CanCreateSchool()
        {
            var createdSchool = new School();
            Assert.IsNotNull(createdSchool);
        }

        /// <summary>
        /// A test that ensures that the School class derives from Organization.
        /// </summary>
        [TestMethod]
        public void SchoolDerivesFromOrganization()
        {
            var createdSchool = new School();
            Assert.IsInstanceOfType(createdSchool, typeof(Organization));
        }

        /// <summary>
        /// A test that ensures the SemiannualTuition property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteSemiannualTuition()
        {
            var createdSchool = new School();
            createdSchool.SemiannualTuition = 3;
            Assert.AreEqual(3, createdSchool.SemiannualTuition);
        }

        /// <summary>
        /// A test that ensures the HasFootballTeam property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteHasFootballTeam()
        {
            var createdSchool = new School();
            createdSchool.HasFootballTeam = true;
            Assert.AreEqual(true, createdSchool.HasFootballTeam);
        }

        /// <summary>
        /// A test that ensures the Students property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteStudents()
        {
            var createdSchool = new School();
            List<Student> testList = new List<Student> { new Student() };
            createdSchool.Students = testList;
            Assert.AreEqual(testList, createdSchool.Students);
        }
    }
}
