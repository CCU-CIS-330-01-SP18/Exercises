using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A generic class that holds the AssociationName and AssociationLocation properties and is inherited from Organization.
    /// </summary>
    class Association : Organization
    {
        public string AssociationName
        {
            get;
            set;
        }
        public string AssociationLocation
        {
            get;
            set;
        }
    }
}
