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
            Student s = new Student();
            Assert.IsNotNull(s);
        }

        [TestMethod]
        public void IsDescendantOfIndividual()
        {
            Student s = new Student();
            Assert.IsInstanceOfType(s, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteCradeClassification()
        {
            Student s = new Student();
            s.GradeClassification = 18;
            Assert.AreEqual(18, s.GradeClassification);
        }

        [TestMethod]
        public void CanReadWriteGPA()
        {
            Student s = new Student();
            s.GPA = 3.1;
            Assert.AreEqual(3.1, s.GPA);
        }

        [TestMethod]
        public void CanReadWriteID()
        {
            Student s = new Student();
            s.ID = 0464940;
            Assert.AreEqual(0464940, s.ID);
        }
    }
}
