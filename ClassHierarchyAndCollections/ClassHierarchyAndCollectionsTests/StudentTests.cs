using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            i.StudentBusiness = "Wendy's";
            Assert.AreEqual("Wendy's", i.StudentBusiness);
        }

        [TestMethod]
        public void CanGetSetDateJoined()
        {
            Student i = new Student();
            i.DateJoined = DateTime.Now;
            Assert.AreEqual(DateTime.Now, i.DateJoined);
        }

        [TestMethod]
        public void IsAnIndividual()
        {
            Student i = new Student();
            Assert.IsInstanceOfType(i, typeof(Individual));
        }
    }
}
