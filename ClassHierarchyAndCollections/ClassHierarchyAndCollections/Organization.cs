using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a Organization with a OrganizationName (String) and a OrganizationAddress (String).
    /// </summary>
    public class Organization: Contact
    {
        public string OrganizationName { get; set; }
        public string OrganizaitonAddress { get; set; }
    }
}
