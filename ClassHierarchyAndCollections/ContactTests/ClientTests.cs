using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CanCreateClient()
        {
            Client c = new Client();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void IsDescentdantOfIndividual()
        {
            Client c = new Client();
            Assert.IsInstanceOfType(c, typeof(Individual));
        }

        [TestMethod]
        public void CanReadWriteContractStartDate()
        {
            Client c = new Client();
            DateTime d = DateTime.Now;
            c.ContractStartDate = d;
            Assert.AreEqual(d.Date, c.ContractStartDate.Date);
        }

        [TestMethod]
        public void CanReadWriteContractValue()
        {
            Client c = new Client();
            c.CotnractValue = 45000m;
            Assert.AreEqual(45000m, c.CotnractValue);
        }
    }
}
