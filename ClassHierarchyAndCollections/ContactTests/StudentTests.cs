using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactTests
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
        public void IsDescendantOfIndividual()
        {
            Student student = new Student();
            Assert.IsInstanceOfType(student, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteCradeClassification()
        {
            Student student = new Student();
            student.GradeClassification = 18;
            Assert.AreEqual(18, student.GradeClassification);
        }

        [TestMethod]
        public void CanReadWriteGPA()
        {
            Student student = new Student();
            student.GPA = 3.1;
            Assert.AreEqual(3.1, student.GPA);
        }

        [TestMethod]
        public void CanReadWriteID()
        {
            Student student = new Student();
            student.ID = 0464940;
            Assert.AreEqual(0464940, student.ID);
        }
    }
}
