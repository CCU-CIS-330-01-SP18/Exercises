using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ClassHierarchyAndCollections;

namespace ContactTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void CanCreateSchool()
        {
            School school = new School();
            Assert.IsNotNull(school);
        }

        [TestMethod]
        public void IsDescendantofOrganization()
        {
            School school = new School();
            Assert.IsInstanceOfType(school, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteStudens()
        {
            School school = new School();
            school.Students = new List<Student>();
            Student student = new Student();
            school.Students.Add(student);
            Assert.AreEqual(student, school.Students[0]);
        }

        [TestMethod]
        public void CanReadWriteIsPrivate()
        {
            School school = new School();
            school.IsPrivate = true;
            Assert.AreEqual(true, school.IsPrivate);
        }

        [TestMethod]
        public void CanUseInterface()
        {
            School school = new School();
            school.Students = new List<Student>();
            Student student1 = new Student();
            student1.DisplayName = "Bob";
            Student student2 = new Student();
            student2.DisplayName = "Joe";
            Student student3 = new Student();
            student3.DisplayName = "Sue";
            school.Students.Add(student1);
            school.Students.Add(student2);
            school.Students.Add(student3);

            school.ReadList();
        }
    }
}
