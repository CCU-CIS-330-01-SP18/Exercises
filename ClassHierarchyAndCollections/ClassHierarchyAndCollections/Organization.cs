using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Creates an Organization object that derives from the Contact class.
    /// </summary>
    public class Organization : Contact, ILocatable
    {
        public string DisplayOrganizationName { get; set; }

        public string DisplayAddress { get; set; }
    }
}
