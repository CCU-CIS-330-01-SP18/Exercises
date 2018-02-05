using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassHierarchyAndCollectionsTest
{
    /// <summary>
    /// Defines unit tests for the <see cref="School"/> class.
    /// </summary>
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
        public void SchoolDerivesFromOrganization()
        {
            School school = new School();
            Assert.IsInstanceOfType(school, typeof(Organization));
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            School school = new School()
            {
                DisplayName = "Snowden Academy"
            };
            Assert.AreEqual("Snowden Academy", school.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            School school = new School()
            {
                EmailAddress = "contact@snowden.edu"
            };
            Assert.AreEqual("contact@snowden.edu", school.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            School school = new School()
            {
                PhoneNumber = "18007669336"
            };
            Assert.AreEqual("18007669336", school.PhoneNumber);
        }

        [TestMethod]
        public void CanReadWriteMotto()
        {
            School school = new School()
            {
                Motto = "Caffeine is your friend."
            };
            Assert.AreEqual("Caffeine is your friend.", school.Motto);
        }

        [TestMethod]
        public void CanReadWriteFoundingDate()
        {
            var now = DateTime.Now;
            School school = new School()
            {
                FoundingDate = now
            };
            Assert.AreEqual(now, school.FoundingDate);
        }

        [TestMethod]
        public void CanReadWriteCourseCatalog()
        {
            School school = new School();
            school.CourseCatalog.Add("Advanced Programming", 10);
            Assert.AreEqual(10, school.CourseCatalog["Advanced Programming"]);
        }

        [TestMethod]
        public void CanAddStudent()
        {
            School school = new School();
            Student student = new Student();
            school.Roster.Add(student);
            Assert.IsTrue(school.Roster.Contains(student));
        }

        [TestMethod]
        public void CanRemoveStudent()
        {
            School school = new School();
            Student student = new Student();
            school.Roster.Add(student);
            school.Roster.Remove(student);
            Assert.IsFalse(school.Roster.Contains(student));
        }

        [TestMethod]
        public void GoodStudentsGoToDeansList()
        {
            School school = new School();
            Student student = new Student()
            {
                GPA = 4.0
            };
            school.Roster.Add(student);
            school.CalculateDeansList();
            Assert.IsTrue(school.DeansList.Contains(student));
        }

        [TestMethod]
        public void BadStudentsStayOffDeansList()
        {
            School school = new School();
            Student student = new Student()
            {
                GPA = 1.5
            };
            school.Roster.Add(student);
            school.CalculateDeansList();
            Assert.IsFalse(school.DeansList.Contains(student));
        }

        [TestMethod]
        public void CanTeachCourse()
        {
            School school = new School();
            for (int i = 0; i < 5; i++)
            {
                school.Roster.Add(new Student());
            }
            school.CourseCatalog.Add("Advanced Programming", 1000);
            Assert.IsTrue(school.TeachCourse("Advanced Programming"));
        }

        [TestMethod]
        public void CantTeachCourseWithoutStudents()
        {
            School school = new School();
            school.CourseCatalog.Add("Advanced Programming", 1000);
            Assert.IsFalse(school.TeachCourse("Advanced Programming"));
        }

        [TestMethod]
        public void CantTeachCourseWithoutCourse()
        {
            School school = new School();
            for (int i = 0; i < 5; i++)
            {
                school.Roster.Add(new Student());
            }
            Assert.IsFalse(school.TeachCourse("Advanced Programming"));
        }
    }
}
