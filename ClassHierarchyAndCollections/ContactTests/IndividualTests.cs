using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactTests
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
        public void IsDescendantOfContact()
        {
            Individual individual = new Individual();
            Assert.IsInstanceOfType(individual, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteAge()
        {
            Individual individual = new Individual();
            individual.Age = 22;
            Assert.AreEqual(individual.Age, 22);
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Individual individual = new Individual();
            individual.Name = "Dean";
            Assert.AreEqual(individual.Name, "Dean");
        }
    }
}
