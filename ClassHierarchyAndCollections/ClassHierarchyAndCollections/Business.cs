using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    class Business: Organization
    {
        public String BusinessOwner { get; set; }

        public Boolean IsOwnedByDisney { get; set; }
    }
}
