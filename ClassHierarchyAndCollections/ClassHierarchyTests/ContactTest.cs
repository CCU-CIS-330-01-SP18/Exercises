using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyTests
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void CanCreateContact()
        {
            Contact c = new Contact();
        }
    }
}
