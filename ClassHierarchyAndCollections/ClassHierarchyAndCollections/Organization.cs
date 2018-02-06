using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A formal group that was instituted on a specific date in a particular location.
    /// </summary>
    public class Organization : Contact
    {
        public string Province { get; set; }

        public DateTime FormationDate { get; set; }
    }
}
