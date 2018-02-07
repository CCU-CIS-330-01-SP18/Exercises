using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierachyAndCollectionsTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CanCreateStudent()
        {
            var createdStudent = new Student();
            Assert.IsNotNull(createdStudent);
        }

        [TestMethod]
        public void ClientDerivesFromStudent()
        {
            var createdStudent = new Student();
            Assert.IsInstanceOfType(createdStudent, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteStudentName()
        {
            var createdStudent = new Student
            {
                StudentName = "Chad"
            };

            Assert.AreEqual("Chad", createdStudent.StudentName);
        }

        [TestMethod]
        public void CanReadWriteStudentAge()
        {
            var createdStudent = new Student
            {
                StudentAge = 20
            };

            Assert.AreEqual(20, createdStudent.StudentAge);
        }
    }
}
