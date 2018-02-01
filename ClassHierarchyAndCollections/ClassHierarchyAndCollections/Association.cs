using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    public class Association : Organization
    {
        public string AssociationName { get; set; }

        public int AssociationFee { get; set; }
    }
}
