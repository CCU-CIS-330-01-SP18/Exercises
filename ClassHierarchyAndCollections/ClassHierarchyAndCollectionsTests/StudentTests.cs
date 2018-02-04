using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CanInstantiateStudent()
        {
            Student c = new Student();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void IsChildOfIndividual()
        {
            Student c = new Student();
            Assert.IsInstanceOfType(c, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteStudentID()
        {
            Student c = new Student();
            c.StudentID = 0470000;
            Assert.AreEqual(0470000, c.StudentID);
        }

        [TestMethod]
        public void CanReadWriteYear()
        {
            Student c = new Student();
            c.YearInSchool = SchoolYear.Junior;
            Assert.AreEqual(SchoolYear.Junior, c.YearInSchool);
        }
    }
}
