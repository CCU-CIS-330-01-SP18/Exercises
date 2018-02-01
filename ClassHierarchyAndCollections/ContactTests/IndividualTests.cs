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
            Individual i = new Individual();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void IsDescendantOfContact()
        {
            Individual i = new Individual();
            Assert.IsInstanceOfType(i, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteAge()
        {
            Individual i = new Individual();
            i.Age = 22;
            Assert.AreEqual(i.Age, 22);
        }

        [TestMethod]
        public void CanReadWriteName()
        {
            Individual i = new Individual();
            i.Name = "Dean";
            Assert.AreEqual(i.Name, "Dean");
        }
    }
}
