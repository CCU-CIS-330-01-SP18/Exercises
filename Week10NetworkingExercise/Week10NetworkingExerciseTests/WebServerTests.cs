using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week10NetworkingExercise;

namespace Week10NetworkingExerciseTests
{
    [TestClass]
    public class WebServerTests
    {
        [TestMethod]
        public void WebServerResponseOnRootPageIsOfTypeString()
        {
            WebServer.ListenForResponseAsync(3001);

            string searchUrl = "http://localhost:3001/";

            using (var client = new HttpClient())
            {
                Assert.AreEqual("<HTML><BODY> Hello, welcome to my server! Input some numbers into the query paramaters x and y to add some numbers together.</BODY></HTML>", client.GetStringAsync(searchUrl).Result);
            }
        }

        [TestMethod]
        public void WebServerRespondsWithCalculationWhenQueryParamatersAreSpecified()
        {
            WebServer.ListenForResponseAsync(3001);

            string searchUrl = "http://localhost:3001/?x=5&y=4";

            using (var client = new HttpClient())
            {
                Assert.AreEqual("9", client.GetStringAsync(searchUrl).Result);
            }
        }
    }
}
