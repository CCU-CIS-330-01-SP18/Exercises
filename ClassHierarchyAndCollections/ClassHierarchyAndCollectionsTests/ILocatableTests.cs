using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ILocatableTests
    {
        [TestMethod]
        public void ILocatableCanReadWriteLocateProperty()
        {
            Business b = new Business();
            b.Location = "Lakewood";

            Assert.AreEqual("Lakewood", b.Location);
        }

        [TestMethod]
        public void ILocatableCanGetLocation()
        {
            Business b = new Business();
            //b.Location = "Denver";
            string location = b.GetLocation("Denver");

            Assert.AreEqual("Denver", location);
        }
    }
}
