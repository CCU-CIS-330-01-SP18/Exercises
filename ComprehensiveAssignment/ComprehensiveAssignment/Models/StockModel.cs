using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComprehensiveAssignment.Models
{
    /// <summary>
    /// Model of a stock that consists of a Quote and the News relating to it.
    /// </summary>
    public class StockModel
    {
        public Quote Quote { get; set; }

        public List<News> News { get; set; }
    }
}