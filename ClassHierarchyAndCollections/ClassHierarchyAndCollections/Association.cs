using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// 
    /// </summary>
    class Association: Organization
    {
        public String AnnualDues { get; set; }

        public String HeadquartersLocation { get; set; }
    }
}
