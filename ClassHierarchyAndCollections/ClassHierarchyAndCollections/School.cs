using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    public class School : Organization
    {
        public string SchoolName { get; set; }

        public bool IsPublic { get; set; }
    }
}
