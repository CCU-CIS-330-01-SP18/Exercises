using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week10Networking;

namespace Week10NetworkingTests
{
    /// <summary>
    /// Tests for the Addition.cs class.
    /// </summary>
    [TestClass]
    public class AdditionTests
    {
        [TestMethod]
        public void ServerResponseTest()
        {
            int portNumber = new Random().Next(1000, 9999);
            int x = new Random().Next(1, 100);
            int y = new Random().Next(1, 100);

            Addition.HttpMath(new string[] { $"{portNumber}" });

            var client = new WebClient();
            int result = Convert.ToInt32(client.DownloadString(new Uri($"http://localhost:{portNumber}/?x={x}&y={y}")));

            Assert.AreEqual((x + y), result);
        }
    }
}
