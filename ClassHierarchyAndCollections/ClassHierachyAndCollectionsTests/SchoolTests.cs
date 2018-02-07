using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;
using System.Collections.Generic;

namespace ClassHierachyAndCollectionsTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void CanCreateSchool()
        {
            var createdSchool = new School();
            Assert.IsNotNull(createdSchool);
        }

        [TestMethod]
        public void ClientDerivesFromSchool()
        {
            var createdSchool = new School();
            Assert.IsInstanceOfType(createdSchool, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteSchoolName()
        {
            var createdSchool = new School
            {
                SchoolName = "Colorado Christian University"
            };

            Assert.AreEqual("Colorado Christian University", createdSchool.SchoolName);
        }

        [TestMethod]
        public void CanReadWriteStudents()
        {
            List<Student> studentList = new List<Student> { new Student() };
            var createdSchool = new School
            {
                Students = studentList
            };

            Assert.AreEqual(studentList, createdSchool.Students);
        }

        [TestMethod]
        public void CanReadWriteSchoolLocation()
        {
            var createdSchool = new School
            {
                SchoolLocation = "Lakewood"
            };

            Assert.AreEqual("Lakewood", createdSchool.SchoolLocation);
        }
    }
}
