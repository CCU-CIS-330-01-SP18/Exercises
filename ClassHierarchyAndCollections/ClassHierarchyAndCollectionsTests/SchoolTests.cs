using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void CanCreateSchool()
        {
            School school = new School();
            Assert.IsNotNull(school);
        }

        [TestMethod]
        public void SchoolInheritsOrganization()
        {
            School school = new School();
            Assert.IsInstanceOfType(school, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteSchoolName()
        {
            School school = new School();
            school.SchoolName = "CCU";
            Assert.AreEqual("CCU", school.SchoolName);
        }

        [TestMethod]
        public void CanReadWriteSchoolCount()
        {
            School school = new School();
            school.SchoolPrice = 40000;
            Assert.AreEqual(40000, school.SchoolPrice);
        }
    }
}
