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
            School s = new School();
            Assert.IsNotNull(s);
        }

        [TestMethod]
        public void IsDescendantofOrganization()
        {
            School s = new School();
            Assert.IsInstanceOfType(s, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteStudens()
        {
            School s = new School();
            s.Students = new List<Student>();
            Student st = new Student();
            s.Students.Add(st);
            Assert.AreEqual(st, s.Students[0]);
        }

        [TestMethod]
        public void CanReadWriteIsPrivate()
        {
            School s = new School();
            s.IsPrivate = true;
            Assert.AreEqual(true, s.IsPrivate);
        }
    }
}
