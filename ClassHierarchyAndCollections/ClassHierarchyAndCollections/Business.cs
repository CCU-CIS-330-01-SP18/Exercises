using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines a business entity, created for the purposes of driving a profit.
    /// </summary>
    class Business : Organization
    {
        public String BusinessPhone { get; set; }

        public String StockSymbol { get; set; }
    }
}
