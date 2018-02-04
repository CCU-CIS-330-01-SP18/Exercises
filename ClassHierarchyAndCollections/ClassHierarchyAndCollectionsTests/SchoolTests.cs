using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;
using System.Collections.Generic;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void CanInstantiateSchool()
        {
            School c = new School();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void IsChildOfOrganization()
        {
            School c = new School();
            Assert.IsInstanceOfType(c, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteType()
        {
            School c = new School();
            c.SchoolType = SchoolType.University;
            Assert.AreEqual(SchoolType.University, c.SchoolType);
        }

        [TestMethod]
        public void CanReadWriteIsPublic()
        {
            School c = new School();
            c.IsPublic = false;
            Assert.AreEqual(false, c.IsPublic);
        }

        [TestMethod]
        public void CanReadWriteStudents()
        {
            School c = new School();
            List<Student> students = new List<Student>();
            students.Add(new Student());
            c.Students = students;
            Assert.AreEqual(students, c.Students);
        }
    }
}
