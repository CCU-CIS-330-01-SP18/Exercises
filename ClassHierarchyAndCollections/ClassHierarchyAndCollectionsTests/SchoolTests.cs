using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void CanCreateSchool()
        {
            School s = new School(); 
            Assert.IsNotNull(s);
        }

        [TestMethod]
        public void SchoolDerivesFromOrganization()
        {
            School s = new School();
            Assert.IsInstanceOfType(s, typeof(Organization));
        }

        [TestMethod]
        public void SchoolCanReadWriteSchoolName()
        {
            School s = new School();
            s.SchoolName = "CCU";
            Assert.AreEqual("CCU", s.SchoolName);
        }

        [TestMethod]
        public void SchoolCanReadWriteIsPublic()
        {
            School s = new School();
            s.IsPublic = false;
            Assert.AreEqual(false, s.IsPublic);
        }
    }
}

