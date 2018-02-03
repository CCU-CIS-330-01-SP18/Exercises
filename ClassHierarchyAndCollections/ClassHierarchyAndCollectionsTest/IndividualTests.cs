using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTest
{
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
    }
}
