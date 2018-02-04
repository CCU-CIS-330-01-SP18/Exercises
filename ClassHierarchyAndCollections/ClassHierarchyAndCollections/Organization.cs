using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{

    /// <summary>
    /// Represents an Organization with an Address and an IsForProfit status.
    /// </summary>
    public class Organization : Contact
    {
        public string HeadQuartersAddress { get; set; }

        public bool IsForProfit { get; set; }
    }
}
