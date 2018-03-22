using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week10Networking;

namespace Week10NetworkingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SadTest()
        {
            var webCalculator = new WebCalculator();
            webCalculator.Main(null);
        }
    }
}
