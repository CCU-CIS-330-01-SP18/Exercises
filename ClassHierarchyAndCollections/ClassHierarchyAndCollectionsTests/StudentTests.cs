using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CanMakeStudent()
        {
            Student i = new Student();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void CanGetSetLevelOfStudentship()
        {
            Student i = new Student();
            i.StudentGradePointAverage = 4;
            Assert.AreEqual(4, i.StudentGradePointAverage);
        }

        [TestMethod]
        public void CanGetSetDateJoined()
        {
            Student i = new Student();
            i.StudentSchool = "Hogwarts";
            Assert.AreEqual("Hogwarts", i.StudentSchool);
        }

        [TestMethod]
        public void IsAnIndividual()
        {
            Student i = new Student();
            Assert.IsInstanceOfType(i, typeof(Individual));
        }
    }
}
