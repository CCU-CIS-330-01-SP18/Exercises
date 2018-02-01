using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollectionsTests
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
        public void OrganizationCanReadWriteDisplayOrganizationName()
        {
            Organization o = new Organization();
            o.DisplayOrganizationName = "XLedger";
            Assert.AreEqual("XLedger", o.DisplayOrganizationName);
        }

        [TestMethod]
        public void OrganizationCanReadWriteDisplayAddress()
        {
            Organization o = new Organization();
            o.DisplayAddress = "123 abc st.";
            Assert.AreEqual("123 abc st.", o.DisplayAddress);
        }
    }
}
