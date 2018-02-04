using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines an organization of people.
    /// </summary>
    public class Organization : Contact
    {
        public String PhysicalAddress { get; set; }

        public DateTime FormationDate { get; set; }
    }
}
