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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FetchStock(Quote model)
        {
            StockModel stockModel = null;
            using (var webClient = new WebClient())
            {
                
                string rawJson = webClient.DownloadString($"https://api.iextrading.com/1.0/stock/{model.Symbol}/batch?types=quote,news,chart&range=1m&last=10");

                stockModel = JsonConvert.DeserializeObject<StockModel>(rawJson);
  
            }

            var quote = new Quote()
            {
                CompanyName = stockModel.Quote.CompanyName,
                Sector = stockModel.Quote.Sector,
                PrimaryExchange = stockModel.Quote.PrimaryExchange
            };

            ViewBag.Name = stockModel.Quote.CompanyName;

            ViewBag.Sector = stockModel.Quote.Sector;

            ViewBag.Exchange = stockModel.Quote.PrimaryExchange;

            ViewBag.Open = stockModel.Quote.Open;

            ViewBag.Close = stockModel.Quote.Close;

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