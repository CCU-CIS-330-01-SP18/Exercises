using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    /// <summary>
    /// A compilation of tests that ensures that instances of Student can be created, their class derives from Individual,
    /// and that their properties can be written to and read.
    /// </summary>
    [TestClass]
    public class StudentTest
    {
        /// <summary>
        /// A test that ensures that instances of Student can be created.
        /// </summary>
        [TestMethod]
        public void CanCreateStudent()
        {
            var createdStudent = new Student();
            Assert.IsNotNull(createdStudent);
        }

        /// <summary>
        /// A test that ensures that the Student class derives from Individual.
        /// </summary>
        [TestMethod]
        public void StudentDerivesFromIndividual()
        {
            var createdStudent = new Student();
            Assert.IsInstanceOfType(createdStudent, typeof(Individual));
        }

        /// <summary>
        /// A test that ensures the TotalCourseCredits property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteTotalCourseCredits()
        {
            var createdStudent = new Student();
            createdStudent.TotalCourseCredits = 3;
            Assert.AreEqual(3, createdStudent.TotalCourseCredits);
        }

        /// <summary>
        /// A test that ensures the CurrentMajor property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteCurrentMajor()
        {
            var createdStudent = new Student();
            createdStudent.CurrentMajor = "Test";
            Assert.AreEqual("Test", createdStudent.CurrentMajor);
        }
    }
}
