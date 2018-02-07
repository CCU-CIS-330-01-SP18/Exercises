using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierachyAndCollectionsTests
{
    [TestClass]
    public class IndividualTests
    {
        [TestMethod]
        public void CanCreateIndividual()
        {
            var createdIndividual = new Individual();
            Assert.IsNotNull(createdIndividual);
        }

        [TestMethod]
        public void ClientDerivesFromContact()
        {
            var createdIndividual = new Individual();
            Assert.IsInstanceOfType(createdIndividual, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteAge()
        {
            var createdIndividual = new Individual
            {
                Age = 20
            };

            Assert.AreEqual(20, createdIndividual.Age);
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            var createdIndividual = new Individual
            {
                Name = "Chad"
            };

            Assert.AreEqual("Chad", createdIndividual.Name);
        }
    }
}
