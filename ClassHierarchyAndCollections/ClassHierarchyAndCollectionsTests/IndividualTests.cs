using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class IndividualTests
    {
        [TestMethod]
        public void CanInstantiateIndividual()
        {
            Individual c = new Individual();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void IsChildOfContact()
        {
            Individual c = new Individual();
            Assert.IsInstanceOfType(c, typeof(Contact));
        }

        [TestMethod]
        public void CanReadWriteCell()
        {
            Individual c = new Individual();
            c.CellPhone = "303-963-3444";
            Assert.AreEqual("303-963-3444", c.CellPhone);
        }

        [TestMethod]
        public void CanReadWriteBirthday()
        {
            Individual c = new Individual();
            DateTime currentTime = DateTime.Now;
            c.Birthday = currentTime;
            Assert.AreEqual(currentTime, c.Birthday);
        }
    }
}
