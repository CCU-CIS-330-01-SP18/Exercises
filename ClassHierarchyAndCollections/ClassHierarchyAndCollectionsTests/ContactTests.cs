using System;
using ClassHierarchyAndCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void CanCreateContact()
        {
            Contact c = new Contact();
        }
    }
}
