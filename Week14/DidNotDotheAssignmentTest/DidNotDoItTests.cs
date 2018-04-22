using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14;

namespace DidNotDotheAssignmentTest
{
    [TestClass]
    public class DidNotDoItTests
    {
        [TestMethod]
        public void FailedTestOne()
        {
            DidNotDotheAssignment.Main();
        }
    }
}
