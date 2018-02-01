using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ContactTests
{
    [TestClass]
    public class OrganizationTests
    {
        [TestMethod]
        public void CanCreateOrganization()
        {

             Organization o = new Organization();
            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void OrganizationDerivesFromContact()
        {
            Organization o = new Organization();
            Assert.IsInstanceOfType(o, typeof(Contact));
        }
        [TestMethod]
        public void CanReadWriteAddress()
        {
            Organization o = new Organization();
            o.Address = "123 Test Street";
            Assert.AreEqual("123 Test Street",o.Address);
        }
        [TestMethod]
        public void CanReadWriteIsForProfit()
        {
            Organization o = new Organization();
            o.IsForProfit = false;
            Assert.AreEqual(false, o.IsForProfit);
        }
    }
}

