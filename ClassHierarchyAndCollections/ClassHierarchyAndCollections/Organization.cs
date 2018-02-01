using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents an Organization with an Address and an IsForProfit status.
/// </summary>
namespace ClassHierarchyAndCollections
{
    public class Organization : Contact
    {
        public string Address { get; set; }

        public bool IsForProfit { get; set; }
    }
}
