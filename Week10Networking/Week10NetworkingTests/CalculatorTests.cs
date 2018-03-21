using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week10Networking;

namespace Week10NetworkingTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PortRangeIsChecked()
        {
            Calculator.Main(new string[] {"1000"});
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PortIsValidInteger()
        {
            Calculator.Main(new string[] { "abc123" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentCountIsChecked()
        {
            Calculator.Main(new string[] { });
        }

        [TestMethod]
        public void ServerIsOpenedAndRespondsProperly()
        {
            var port = 2048;

            Calculator.Main(new string[] { Convert.ToString(port) });

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetStringAsync("http://localhost:" + port + "/?first=1&second=1&operation=add").Result;
                Assert.AreEqual(response, "Your result is 2!");
            }
        }
    }
}
