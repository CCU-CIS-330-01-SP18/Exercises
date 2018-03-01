using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;

namespace Week7ThreadingTests
{
    /// <summary>
    /// This program is very simple, so these tests are designed to ensure that the system has proper error checking.
    /// </summary>
    [TestClass]
    public class PageDownloaderTests
    {
        [TestMethod]
        public void CanDownloadWebpage()
        {
            Assert.IsNotNull(PageDownloader.DownloadWebpage("http://google.com"));
        }

        [TestMethod]
        public void DoesNotAddBadValues()
        {
            Dictionary<string, long> testDictionary = new Dictionary<string, long>();
            string testURL = "http://google.com";
            long testDuration = -1;

            PageDownloader.addToDictionary(testDictionary, testURL, testDuration);

            Assert.IsFalse(testDictionary.ContainsKey(testURL));
        }

        [TestMethod]
        public void DoesAddGoodValues()
        {
            Dictionary<string, long> testDictionary = new Dictionary<string, long>();
            string testURL = "http://yahoo.com";
            long testDuration = 1000;

            PageDownloader.addToDictionary(testDictionary, testURL, testDuration);

            Assert.IsTrue(testDictionary.ContainsKey(testURL));
        }
    }
}
