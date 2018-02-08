using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CanCreateStudent()
        {
            Student s = new Student();
            Assert.IsNotNull(s);
        }

        [TestMethod]
        public void StudentDerivesFromIndividual()
        {
            Student s = new Student();
            Assert.IsInstanceOfType(s, typeof(Individual));
        }

        [TestMethod]
        public void StudentCanReadWriteStudentName()
        {
            Student s = new Student();
            s.StudentName = "Ryan";
            Assert.AreEqual("Ryan", s.StudentName);
        }

        [TestMethod]
        public void StudentCanReadWriteGPA()
        {
            Student s = new Student();
            s.GPA = 3.0f;
            Assert.AreEqual(3.0f, s.GPA);
        }
    }
}
