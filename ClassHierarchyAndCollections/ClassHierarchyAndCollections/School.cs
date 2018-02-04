using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines an educational facility.
    /// </summary>
    class School : Organization
    {
        public SchoolType SchoolType { get; set; }

        public bool IsPublic { get; set; }

        public List<Student> Students { get; set; }
    }
}
