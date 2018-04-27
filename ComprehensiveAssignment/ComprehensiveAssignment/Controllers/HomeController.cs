using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComprehensiveAssignment.Models;
using Newtonsoft.Json;

namespace ComprehensiveAssignment.Controllers
{
    /// <summary>
    /// Controller that is present for the home views when user logs in.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The main Action of the application for the Home Controller.
        /// </summary>
        /// <returns>The Index.cshtml View under Home</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action that fetches stock symbol from view and applies it to api call.
        /// </summary>
        /// <param name="model">Quote Symbol being returned to controller.</param>
        /// <returns>Returns the Index view and passes it a Quote model with updated stock info from api call.</returns>
        [HttpGet]
        public ActionResult FetchStock(Quote model)
        {
            StockModel stockModel = null;
            using (var webClient = new WebClient())
            {
                // Download JSON
                string rawJson = webClient.DownloadString($"https://api.iextrading.com/1.0/stock/{model.Symbol}/batch?types=quote,news,chart&range=1m&last=10");

                // Deserialize JSON.
                stockModel = JsonConvert.DeserializeObject<StockModel>(rawJson);
  
            }

            // Model that I'm passing to the view.
            var quote = new Quote()
            {
                CompanyName = stockModel.Quote.CompanyName,
                Sector = stockModel.Quote.Sector,
                PrimaryExchange = stockModel.Quote.PrimaryExchange,
                Open = stockModel.Quote.Open,
                Close = stockModel.Quote.Close
            };

            return View("Index", quote);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}