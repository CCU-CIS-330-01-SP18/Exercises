using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Provides the details of a school.
    /// </summary>
    class School : Organization
    {
        public String SchoolDistrict { get; set; }

        public String SuperintendentName { get; set; }
    }
}
