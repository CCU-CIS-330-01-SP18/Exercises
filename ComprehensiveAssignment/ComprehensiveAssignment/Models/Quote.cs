using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComprehensiveAssignment.Models
{
    /// <summary>
    /// Model of a quote that will represent stock information.
    /// </summary>
    public class Quote
    {
        [Required(ErrorMessage = "Field Cannot Be Empty")]
        public string Symbol { get; set; }

        public string CompanyName { get; set; }

        public string PrimaryExchange { get; set; }

        public string Sector { get; set; }

        public double Open { get; set; }

        public double Close { get; set; }
    }
}