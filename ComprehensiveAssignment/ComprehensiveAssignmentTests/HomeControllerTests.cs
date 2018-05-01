using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComprehensiveAssignment;
using ComprehensiveAssignment.Controllers;
using System.Web.Mvc;
using ComprehensiveAssignment.Models;
using System.Net;
using Newtonsoft.Json;

namespace ComprehensiveAssignmentTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void HomeIndex()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.About() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HomeControllerCanFetchStockData()
        {
            StockModel stockModel = null;

            string company = "fb";

            using (var webClient = new WebClient())
            {
                // Download JSON
                string rawJson = webClient.DownloadString($"https://api.iextrading.com/1.0/stock/{company}/batch?types=quote,news,chart&range=1m&last=10");

                // Deserialize JSON.
                stockModel = JsonConvert.DeserializeObject<StockModel>(rawJson);
            }

            Assert.IsNotNull(stockModel);

            Assert.AreEqual("Facebook Inc.", stockModel.Quote.CompanyName);
        }

        [TestMethod]
        public void HomeControllerCanFetchRelatedNews()
        {
            StockModel stockModel = null;

            string company = "fb";

            using (var webClient = new WebClient())
            {
                // Download JSON
                string rawJson = webClient.DownloadString($"https://api.iextrading.com/1.0/stock/{company}/batch?types=quote,news,chart&range=1m&last=10");

                // Deserialize JSON.
                stockModel = JsonConvert.DeserializeObject<StockModel>(rawJson);
            }

            var list = stockModel.News.ToArray();

            Assert.IsNotNull(list);
        }
    }
}
