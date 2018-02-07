using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    class Organization: Contact
    {
        public DateTime FormationDate { get; set; }

        public String OrganizationName { get; set; }
    }
}
