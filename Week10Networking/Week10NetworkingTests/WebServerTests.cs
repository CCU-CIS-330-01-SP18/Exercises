using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void DoesNotRespondToBadQueryString()
        {
            ushort port = 8080;
            var client = new HttpClient();
            var uri = new UriBuilder("http", "localhost", port, "?x=ten&y=twenty");
            Task.Run(() => WebServer.RunWebListener(port));
            var response = client.GetAsync(uri.ToString());
        }
    }
}
