using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTest
{
    /// <summary>
    /// Defines unit tests for the <see cref="Student"/> class.
    /// </summary>
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CanCreateStudent()
        {
            Student student = new Student();
            Assert.IsNotNull(student);
        }

        [TestMethod]
        public void StudentDerivesFromIndividual()
        {
            Student student = new Student();
            Assert.IsInstanceOfType(student, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteGPA()
        {
            Student student = new Student()
            {
                GPA = 3.5
            };
            Assert.AreEqual(3.5, student.GPA);
        }

        [TestMethod]
        public void CanReadStressLevel()
        {
            Student student = new Student()
            {
                EmotionalStability = 1
            };
            student.Study(5);
            Assert.AreEqual(5, student.StressLevel);
        }

        [TestMethod]
        public void CanReadWriteEmotionalStability()
        {
            Student student = new Student()
            {
                EmotionalStability = 5
            };
            Assert.AreEqual(5, student.EmotionalStability);
        }

        [TestMethod]
        public void StressResetsOnBreakDown()
        {
            Student student = new Student()
            {
                EmotionalStability = 0.25
            };
            student.Study(5000);
            Assert.AreEqual(0, student.StressLevel);
        }

        [TestMethod]
        public void GPAModifiedOnStudy()
        {
            Student student = new Student()
            {
                EmotionalStability = double.MaxValue
            };
            double startingGPA = student.GPA;
            // There is no kill like overkill.
            student.Study(int.MaxValue);
            Assert.AreNotEqual(startingGPA, student.GPA);
        }

        [TestMethod]
        public void GPACutOnBreakDown()
        {
            Student student = new Student()
            {
                EmotionalStability = 0.25
            };
            student.Study(5000);
            // The student's GPA is cut by 25% on a breakdown; at maximum it can be 3.0 afterward.
            Assert.IsTrue(student.GPA <= 3.0);
        }

        [TestMethod]
        public void StressMinimumOfZero()
        {
            Student student = new Student();
            student.Destress();
            Assert.AreEqual(0, student.StressLevel);
        }

        [TestMethod]
        public void DestressLowersStressLevel()
        {
            Student student = new Student()
            {
                EmotionalStability = 1
            };
            student.Study(5);
            student.Destress();
            Assert.IsTrue(5 > student.StressLevel);
        }
    }
}
