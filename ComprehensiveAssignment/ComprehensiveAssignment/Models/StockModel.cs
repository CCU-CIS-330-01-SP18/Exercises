using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComprehensiveAssignment.Models
{
    public class StockModel
    {
        public Quote Quote { get; set; }
        public List<News> News { get; set; }
    }
}