using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Week10Networking;

namespace Week10NetworkingTests
{
    [TestClass]
    public class WebServerTests
    {
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void HandlesOutOfRangePort()
        {
            string portNumber = "-7";
            WebServer.ParseArgument(portNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void HandlesNonNumericPort()
        {
            string portNumber = "Not A Number";
            WebServer.ParseArgument(portNumber);
        }

        [TestMethod]
        public void BadRequestOnBadQueryString()
        {
            ushort port = 8080;
            Task.Run(() => WebServer.RunWebListener(port));

            var badStrings = new string[] {
                "?x=ten&y=twenty",
                "?x=10&y=twenty",
                "?x=ten&y=20",
                "?x=10",
                "?y=20",
                "?z=30"
            };

            var client = new HttpClient();
            var uri = new UriBuilder("http", "localhost", port, badStrings[0]);
            var response = client.GetAsync(uri.ToString());
            Assert.AreEqual(HttpStatusCode.BadRequest, response.Result.StatusCode);

            for (int i = 1; i < badStrings.Length; i++)
            {
                uri.Path = badStrings[i];
                response = client.GetAsync(uri.ToString());
                Assert.AreEqual(HttpStatusCode.BadRequest, response.Result.StatusCode, $"String \"{badStrings[i]}\" did not return a HTTP 400 code.");
            }
        }

        [TestMethod]
        public void OKOnGoodQueryString()
        {
            ushort port = 8080;
            var client = new HttpClient();
            var uri = new UriBuilder("http", "localhost", port, "?x=10&y=20");

            Task.Run(() => WebServer.RunWebListener(port));
            var response = client.GetAsync(uri.ToString());
            string res = response.Result.ReasonPhrase;
            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
        }
    }
}
