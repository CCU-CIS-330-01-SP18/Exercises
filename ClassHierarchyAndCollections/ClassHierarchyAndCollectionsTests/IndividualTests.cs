using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
