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
        public void CanReadWriteName()
        {
            Student student = new Student()
            {
                DisplayName = "Joe Cool"
            };
            Assert.AreEqual("Joe Cool", student.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Student student = new Student()
            {
                EmailAddress = "jcool@ccu.edu"
            };
            Assert.AreEqual("jcool@ccu.edu", student.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Student student = new Student()
            {
                PhoneNumber = "9705551234"
            };
            Assert.AreEqual("9705551234", student.PhoneNumber);
        }

        [TestMethod]
        public void CanReadWriteGender()
        {
            Student student = new Student()
            {
                Gender = Gender.Male
            };
            Assert.AreEqual(Gender.Male, student.Gender);
        }

        [TestMethod]
        public void CanReadNumberOfRemainingKidneys()
        {
            Student student = new Student();
            Assert.AreEqual(2, student.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanReadNumberOfRemainingLungs()
        {
            Student student = new Student();
            Assert.AreEqual(2, student.NumberOfRemainingLungs);
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
        public void CanRemoveOrgans()
        {
            Student student = new Student();
            Assert.IsTrue(student.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotRemoveAllOrgans()
        {
            Student student = new Student();
            student.RemoveOrgan(Organ.Kidney);
            Assert.IsFalse(student.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanTransplantOrgans()
        {
            Student student = new Student();
            student.RemoveOrgan(Organ.Kidney);
            Assert.IsTrue(student.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotTransplantMoreOrgans()
        {
            Student student = new Student();
            Assert.IsFalse(student.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanRemoveKidneys()
        {
            Student student = new Student();
            int startingCount = student.NumberOfRemainingKidneys;
            student.RemoveOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount - 1, student.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanRemoveLungs()
        {
            Student student = new Student();
            int startingCount = student.NumberOfRemainingLungs;
            student.RemoveOrgan(Organ.Lung);
            Assert.AreEqual(startingCount - 1, student.NumberOfRemainingLungs);
        }

        [TestMethod]
        public void CanTransplantKidneys()
        {
            Student student = new Student();
            student.RemoveOrgan(Organ.Kidney);
            int startingCount = student.NumberOfRemainingKidneys;
            student.TransplantOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount + 1, student.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanTransplantLungs()
        {
            Student student = new Student();
            student.RemoveOrgan(Organ.Lung);
            int startingCount = student.NumberOfRemainingLungs;
            student.TransplantOrgan(Organ.Lung);
            Assert.AreEqual(startingCount + 1, student.NumberOfRemainingLungs);
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
