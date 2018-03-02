using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;

namespace Week7ThreadingTests
{
    [TestClass]
    public class Week7Tests
    {
        [TestMethod]
        public void BasicAsyncCheck()
        {
            Assert.IsNotNull(Week7.GetAsync("http://google.com"));
        }
    }
}
