using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines a singular individual or person.
    /// </summary>
    public class Individual : Contact
    {
        public String CellPhone { get; set; }

        public DateTime Birthday { get; set; }
    }
}
