using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactHierarchyTests
{
    /// <summary>
    /// A compilation of tests that ensures that instances of Individual can be created, their class derives from Contact,
    /// and that their properties can be written to and read.
    /// </summary>
    [TestClass]
    public class IndividualTest
    {
        /// <summary>
        /// A test that ensures that instances of Individual can be created.
        /// </summary>
        [TestMethod]
        public void CanCreateIndividual()
        {
            var createdIndividual = new Individual();
            Assert.IsNotNull(createdIndividual);
        }

        /// <summary>
        /// A test that ensures that the Individual class derives from Contact.
        /// </summary>
        [TestMethod]
        public void IndividualDerivesFromContact()
        {
            var createdIndividual = new Individual();
            Assert.IsInstanceOfType(createdIndividual, typeof(Contact));
        }

        /// <summary>
        /// A test that ensures the EmailAddress property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteEmailAddress()
        {
            var createdIndividual = new Individual();
            createdIndividual.EmailAddress = "Test";
            Assert.AreEqual("Test", createdIndividual.EmailAddress);
        }

        /// <summary>
        /// A test that ensures the CellNumber property can be written to and read.
        /// </summary>
        [TestMethod]
        public void CanReadWriteCellNumber()
        {
            var createdIndividual = new Individual();
            createdIndividual.CellNumber = "Test";
            Assert.AreEqual("Test", createdIndividual.CellNumber);
        }
    }
}
