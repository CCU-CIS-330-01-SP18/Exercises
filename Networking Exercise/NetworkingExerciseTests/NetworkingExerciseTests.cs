using System;
using NetworkingExercise;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetworkingExerciseTests
{
    [TestClass]
    public class NetworkingTests
    {
        [TestMethod]
        public void WebServerResponseStringTests()
        {
            WebServer.ListenAsync(5002);

            string searchUrl = "http://localhost:5002/";
            string responseString = "<HTML><BODY> Hello User! Put in some numbers!</BODY></HTML>";

            using (var client = new HttpClient())
            {
                Assert.AreEqual(responseString, client.GetStringAsync(searchUrl).Result);
            }
        }

        [TestMethod]
        public void WebServerUrlCalculateTests()
        {
            WebServer.ListenAsync(1234);
            string searchUrl = "http://localhost:1234/?x=5&y=4";

            using (var client = new HttpClient())
            {
                Assert.AreEqual("9", client.GetStringAsync(searchUrl).Result);
            }
        }
 
        [TestMethod]
        public void WebProgramException()
        {
            WebServer.ListenAsync(5001);
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:5001/?x=hello&y=world");

            Assert.ThrowsException<WebException>(() => (HttpWebResponse)request.GetResponse());
        }
    }
}
