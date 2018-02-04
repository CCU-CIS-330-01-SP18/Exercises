using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyTests
{
    /// <summary>
    /// Tests the functionality of the Individual class.
    /// </summary>
    [TestClass]
    public class IndividualTest
    {
        /// <summary>
        /// Tests to see if you can create an instance of the class.
        /// </summary>
        [TestMethod]
        public void CanCreateIndividual()
        {
            Individual i = new Individual();
            Assert.IsNotNull(i);
        }

        /// <summary>
        /// Tests if the class correctly inherets the specified hierarchy.
        /// </summary>
        [TestMethod]
        public void ContentDerivesFromDirectContent()
        {
            Individual i = new Individual();
            Assert.IsInstanceOfType(i, typeof(Contact));
        }

        /// <summary>
        /// Tests the read/write capability of the first property.
        /// </summary>
        [TestMethod]
        public void IndividualCanReadWritePreferedName()
        {
            Individual i = new Individual();
            i.PreferredName = "Dylicious";
            Assert.AreEqual("Dylicious", i.PreferredName);
        }

        /// <summary>
        /// Tests the read/write capability of the second property.
        /// </summary>
        [TestMethod]
        public void IndividualCanReadWritePreferredMethodOfContact()
        {
            Individual i = new Individual();
            i.PreferredMethodOfContact = "Text";
            Assert.AreEqual("Text", i.PreferredMethodOfContact);
        }
    }
}
