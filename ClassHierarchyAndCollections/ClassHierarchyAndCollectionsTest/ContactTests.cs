using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchyAndCollections;

namespace ClassHierarchyAndCollectionsTests
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void CanCreateContact()
        {
            Contact contact = new Contact("John Doe", "jdoe@ccu.edu", "01189998819991197253");
        }
    }
}
