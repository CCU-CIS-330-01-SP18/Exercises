using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Provides the details of an organization.
    /// </summary>
    public class Organization : Contact
    {
        public String FormationDate { get; set; }

        public String OrganizationName { get; set; }
    }
}
