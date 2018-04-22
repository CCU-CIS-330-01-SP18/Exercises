using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotDisposing;

namespace NotDisposingTests
{
    [TestClass]
    public class NotDisposingTest
    {
        [TestMethod]
        public void DoesHelloWorld()
        {
            NoDisposing.Main();
        }
    }
}
