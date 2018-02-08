using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class IndividualTests
    {
        [TestMethod]
        public void CanCreateIndividual()
        {
            Individual i = new Individual();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void IndividualDerivesFromContact()
        {
            Individual i = new Individual();
            Assert.IsInstanceOfType(i, typeof(Contact));
        }

        [TestMethod]
        public void IndividualCanReadWriteFirstName()
        {
            Individual i = new Individual();
            i.FirstName = "Ryan";
            Assert.AreEqual("Ryan", i.FirstName);
        }

        [TestMethod]
        public void IndividualCanReadWriteLastName()
        {
            Individual i = new Individual();
            i.LastName = "Hurley";
            Assert.AreEqual("Hurley", i.LastName);
        }
    }
}
