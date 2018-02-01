using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    public class Organization : Contact
    {
        public string DisplayOrganizationName { get; set; }

        public string DisplayAddress { get; set; }
    }
}
