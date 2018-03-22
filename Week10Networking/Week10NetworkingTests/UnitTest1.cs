using System;
using System.Net;
using System.Web;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week10Networking;

namespace Week10NetworkingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidInput()
        {
            var port = 3001;
            Program.StartServer(port);

            string searchUrl = "http://localhost:"+port+"/?x=5&y=4";

            using (var client = new HttpClient())
            {
                Assert.AreEqual("9", client.GetStringAsync(searchUrl).Result);
            }

        }

        [TestMethod]
        public void InvalidInput()
        {
            var port = 3001;
            Program.StartServer(port);

            var webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:"+port+"/?x=what&y=up");

            Assert.ThrowsException<WebException>(() => (HttpWebResponse)webRequest.GetResponse());
        }
    }
}
