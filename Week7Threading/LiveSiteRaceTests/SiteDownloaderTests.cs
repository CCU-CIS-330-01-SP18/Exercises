using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiveSiteRace;

namespace LiveSiteRaceTests
{
    [TestClass]
    public class SiteDownloaderTests
    {
        [TestMethod]
        public void AsyncDownloadTest()
        {
            string[] urlList = new string[] { "https://www.google.com" };

            try
            {
                var downloadedSites = SiteDownloader.AsyncDownload(urlList);

                Assert.IsInstanceOfType(downloadedSites, typeof(List<LoadedWebsite>));
                Assert.AreEqual(urlList.Length, downloadedSites.Count);
                Assert.AreEqual(urlList[0], downloadedSites[0].Url);
            }
            catch(AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    if(ex is System.Net.Http.HttpRequestException)
                    {
                        Assert.Fail("You aren't connected to the internet! Connect and try the test again.");
                    }
                    else if(ex is System.Net.WebException)
                    {
                        Assert.Fail("You aren't connected to the internet! Connect and try the test again.");
                    }
                    else
                    {
                        Assert.Fail(ex.InnerException.Message);
                    }
                }                
            }
        }
    }
}
