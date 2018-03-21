using System;
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
            var uri = new UriBuilder("http", "localhost", 8080, "?x=ten&y=twenty");
            WebServer.RunWebListener(8080);
        }
    }
}
