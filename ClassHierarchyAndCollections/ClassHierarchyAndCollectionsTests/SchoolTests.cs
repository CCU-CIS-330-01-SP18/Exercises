using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void CanMakeSchool()
        {
            School i = new School();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void CanGetSetSchoolDistrict()
        {
            School i = new School();
            i.SchoolDistrict = "123";
            Assert.AreEqual("123", i.SchoolDistrict);
        }

        [TestMethod]
        public void CanGetSetSuperintendentName()
        {
            School i = new School();
            i.SuperintendentName = "Dr. Fillmore";
            Assert.AreEqual("Dr. Fillmore", i.SuperintendentName);
        }

        [TestMethod]
        public void IsAContact()
        {
            School i = new School();
            Assert.IsInstanceOfType(i, typeof(Organization));
        }
    }
}
