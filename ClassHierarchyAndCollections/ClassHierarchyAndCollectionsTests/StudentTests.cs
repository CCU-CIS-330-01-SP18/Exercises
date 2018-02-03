using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CanCreateStudent()
        {
            Student student = new Student();
            Assert.IsNotNull(student);
        }

        [TestMethod]
        public void StudentInheritsIndividual()
        {
            Student student = new Student();
            Assert.IsInstanceOfType(student, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteStudentID()
        {
            Student student = new Student();
            student.StudentID = 0499577;
            Assert.AreEqual(0499577, student.StudentID);
        }

        [TestMethod]
        public void CanReadWriteStudentGPA()
        {
            Student student = new Student();
            student.StudentGPA = 3.9f;
            Assert.AreEqual(3.9f, student.StudentGPA);
        }
    }
}
