using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Networking;

namespace NetworkingTest
{
    [TestClass]
    public class WebServerTest
    {
        [TestMethod]
        public void Can_Pass()
        {
            int portNumber = 8001;
            WebServer.GenerateWebServerAsync(portNumber);

            using(var client = new WebClient())
            {
                // If the keys are x and y, then add their values together.
                int text = Convert.ToInt32(client.DownloadString($"http://localhost:{portNumber}/?x=2&y=3"));
                Assert.AreEqual(text, 5);
            } 
        }

        [TestMethod]
        public void Incorrect_Paramater()
        {
            int portNumber = 8001;
            WebServer.GenerateWebServerAsync(portNumber);

            using (var client = new WebClient())
            {
                // You cannot use anything other than x and y as the keys. This ensures that this is the case.
                int text = Convert.ToInt32(client.DownloadString($"http://localhost:{portNumber}/?a=2&b=3"));
                Assert.AreNotEqual(text, 5);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void Null_Value()
        {
            int portNumber = 8001;
            WebServer.GenerateWebServerAsync(portNumber);

            using (var client = new WebClient())
            {
                // Both x and y must have values.
                int text = Convert.ToInt32(client.DownloadString($"http://localhost:{portNumber}/?x=2&y="));
            }
        }
    }
}

