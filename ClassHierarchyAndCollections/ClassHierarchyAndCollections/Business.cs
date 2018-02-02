using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    public class Business : Organization
    {
        public string BusinessEntity { get; set; }
        
        public int Sales { get; set; }
    }
}
