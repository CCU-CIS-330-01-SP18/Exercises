using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a Business with a BusinessName (String) and a BusinessStockPrice (Float).
    /// </summary>
    public class Business: Organization
    {
        public string BusinessName { get; set; }
        public float BusinessStockPrice { get; set; }
    }
}
