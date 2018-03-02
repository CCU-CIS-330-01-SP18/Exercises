using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiveSiteRace;

namespace LiveSiteRaceTests
{
    [TestClass]
    public class LoadedWebsiteTests
    {
        [TestMethod]
        public void LoadedWebsiteCanCreateAndRead()
        {
            string url = "url";
            string contents = "contents";
            long loadTime = 242;
            int loadPlace = 2;
            var testSite = new LoadedWebsite(url, contents, loadTime, loadPlace);

            Assert.AreEqual(testSite.Url, url);
            Assert.AreEqual(testSite.UrlContents, contents);
            Assert.AreEqual(testSite.LoadTime, loadTime);
            Assert.AreEqual(testSite.LoadPosition, loadPlace);
        }
    }
}
