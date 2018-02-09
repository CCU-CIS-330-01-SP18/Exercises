using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class IndividualTests
    {
        [TestMethod]
        public void CanMakeIndividual()
        {
            Individual i = new Individual();
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void CanGetSetPhoneNumber()
        {
            Individual i = new Individual();
            i.PhoneNumber = "911";
            Assert.AreEqual("911", i.PhoneNumber);
        }

        [TestMethod]
        public void CanGetSetMaritalStatus()
        {
            Individual i = new Individual();
            i.MaritalStatus = "It's Complicated";
            Assert.AreEqual("It's Complicated", i.MaritalStatus);
        }

        [TestMethod]
        public void IsAContact()
        {
            Individual i = new Individual();
            Assert.IsInstanceOfType(i, typeof(Contact));
        }
    }
}
