using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject;

namespace FinalProjectTests
{
    [TestClass]
    public class AddItemsTest
    {
        [TestMethod]
        public void CanAddNameOfItem()
        {
            string name = "Legolas";
            bool outcome = AddItems.AddNameOfItem(name);
            Assert.IsTrue(outcome);
        }

        [TestMethod]
        public void CanAddCostOfItem()
        {
            string cost = "99.99";
            bool outcome = AddItems.AddCostOfItem(cost);
            Assert.IsTrue(outcome);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotAddNullNametOfItem()
        {
            // Null values are not pemitted.
            string name = "";
            AddItems.AddNameOfItem(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotAddNullCosttOfItem()
        {
            // Null values are not pemitted.
            string cost = "";
            AddItems.AddCostOfItem(cost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotAddInvalidValueForNametOfItem()
        {
            // Only letters are permitted.
            string name = "$10.00";
            AddItems.AddNameOfItem(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotAddInvalidValueForCosttOfItem()
        {
            // Only letters are permitted.
            string Cost = "1 million";
            AddItems.AddCostOfItem(Cost);
        }
    }
}
