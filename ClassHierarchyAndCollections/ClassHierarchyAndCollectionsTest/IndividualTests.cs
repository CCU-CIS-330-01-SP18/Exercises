using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTest
{
    /// <summary>
    /// Defines unit tests for the <see cref="Individual"/> class.
    /// </summary>
    [TestClass]
    public class IndividualTests
    {
        [TestMethod]
        public void CanCreateIndividual()
        {
            Individual individual = new Individual();
            Assert.IsNotNull(individual);
        }

        [TestMethod]
        public void IndividualDerivesFromContact()
        {
            Individual individual = new Individual();
            Assert.IsInstanceOfType(individual, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Individual individual = new Individual()
            {
                DisplayName = "Joe Cool"
            };
            Assert.AreEqual("Joe Cool", individual.DisplayName);
        }

        [TestMethod]
        public void CanReadWriteEmail()
        {
            Individual individual = new Individual()
            {
                EmailAddress = "jcool@ccu.edu"
            };
            Assert.AreEqual("jcool@ccu.edu", individual.EmailAddress);
        }

        [TestMethod]
        public void CanReadWritePhone()
        {
            Individual individual = new Individual()
            {
                PhoneNumber = "9705551234"
            };
            Assert.AreEqual("9705551234", individual.PhoneNumber);
        }

        [TestMethod]
        public void CanReadWriteGender()
        {
            Individual individual = new Individual()
            {
                Gender = Gender.Male
            };
            Assert.AreEqual(Gender.Male, individual.Gender);
        }

        [TestMethod]
        public void CanRemoveOrgans()
        {
            Individual individual = new Individual();
            Assert.IsTrue(individual.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotRemoveAllOrgans()
        {
            Individual individual = new Individual();
            individual.RemoveOrgan(Organ.Kidney);
            Assert.IsFalse(individual.RemoveOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanTransplantOrgans()
        {
            Individual individual = new Individual();
            individual.RemoveOrgan(Organ.Kidney);
            Assert.IsTrue(individual.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CannotTransplantMoreOrgans()
        {
            Individual individual = new Individual();
            Assert.IsFalse(individual.TransplantOrgan(Organ.Kidney));
        }

        [TestMethod]
        public void CanRemoveKidneys()
        {
            Individual individual = new Individual();
            int startingCount = individual.NumberOfRemainingKidneys;
            individual.RemoveOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount - 1, individual.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanRemoveLungs()
        {
            Individual individual = new Individual();
            int startingCount = individual.NumberOfRemainingLungs;
            individual.RemoveOrgan(Organ.Lung);
            Assert.AreEqual(startingCount - 1, individual.NumberOfRemainingLungs);
        }

        [TestMethod]
        public void CanTransplantKidneys()
        {
            Individual individual = new Individual();
            individual.RemoveOrgan(Organ.Kidney);
            int startingCount = individual.NumberOfRemainingKidneys;
            individual.TransplantOrgan(Organ.Kidney);
            Assert.AreEqual(startingCount + 1, individual.NumberOfRemainingKidneys);
        }

        [TestMethod]
        public void CanTransplantLungs()
        {
            Individual individual = new Individual();
            individual.RemoveOrgan(Organ.Lung);
            int startingCount = individual.NumberOfRemainingLungs;
            individual.TransplantOrgan(Organ.Lung);
            Assert.AreEqual(startingCount + 1, individual.NumberOfRemainingLungs);
        }
    }
}
