using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
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
        public void IndividualInheritsContact()
        {
            Individual individual = new Individual();
            Assert.IsInstanceOfType(individual, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Individual individual = new Individual();
            individual.Name = "Justin";
            Assert.AreEqual("Justin", individual.Name);
        }

        [TestMethod]
        public void CanReadWriteAge()
        {
            Individual individual = new Individual();
            individual.Age = 21;
            Assert.AreEqual(21, individual.Age);
        }
    }
}
