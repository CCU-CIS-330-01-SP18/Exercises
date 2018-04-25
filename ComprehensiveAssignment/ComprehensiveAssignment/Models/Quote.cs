using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComprehensiveAssignment.Models
{
    public class Quote
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string PrimaryExchange { get; set; }
        public string Sector { get; set; }
        public string CalculationPrice { get; set; }
        public double Open { get; set; }
        public long OpenTime { get; set; }
        public double Close { get; set; }
        public long CloseTime { get; set; }
        public double High { get; set; }
    }
}