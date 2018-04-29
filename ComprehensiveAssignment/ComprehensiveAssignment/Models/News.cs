using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComprehensiveAssignment.Models
{
    /// <summary>
    /// Model from which the related news of a stock is pulled.
    /// </summary>
    public class News
    {
        public string Headline { get; set; }

        public string Source { get; set; }

        public string Url { get; set; }
    }
}