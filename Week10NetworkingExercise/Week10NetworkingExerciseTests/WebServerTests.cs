using System;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week10NetworkingExercise;

namespace Week10NetworkingExerciseTests
{
    [TestClass]
    public class WebServerTests
    {
        [TestMethod]
        public void WebServerResponseOnRootPageRequest()
        {
            WebServer.ListenForResponseAsync(3001);

            string searchUrl = "http://localhost:3001/";

            string responseString = "<HTML><BODY> Hello, welcome to my server! Input some numbers into the query paramaters x and y to add some numbers together.</BODY></HTML>";

            using (var client = new HttpClient())
            {
                Assert.AreEqual(responseString, client.GetStringAsync(searchUrl).Result);
            }
        }

        [TestMethod]
        public void WebServerCalculatesQueryStrings()
        {
            WebServer.ListenForResponseAsync(3001);

            string searchUrl = "http://localhost:3001/?x=5&y=4";

            using (var client = new HttpClient())
            {
                Assert.AreEqual("9", client.GetStringAsync(searchUrl).Result);
            }
        }

        [TestMethod]
        public void WebServerRespondsThrowsWebExceptionWhenValuesArentIntegers()
        {
            WebServer.ListenForResponseAsync(3001);

            // Makes a response to the web server using invalid query parameters.
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:3001/?x=hello&y=world");

            // Returns a 400(Bad Request) response and throws a WebException
            Assert.ThrowsException<WebException>(() => (HttpWebResponse)request.GetResponse());
        }
    }
}
