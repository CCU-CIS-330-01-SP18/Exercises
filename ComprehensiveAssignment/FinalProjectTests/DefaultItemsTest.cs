using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject;

namespace FinalProjectTests
{
    [TestClass]
    public class DefaultItemsTest
    {
        [TestMethod]
        public void CanCreateList()
        {
            var list = DefaultItems.GenerateDefaultItems();
            Assert.IsNotNull(list);
        }
    }
}
