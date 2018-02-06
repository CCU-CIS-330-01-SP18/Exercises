using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A generic class inherited from the Contact class that holds the unique OrganizationAddress and OrganizationNumber properties.
    /// </summary>
    public class Organization : Contact
    {
        public string OrganizationAddress
        {
            get;
            set;
        }

        public int OrganizationNumber
        {
            get;
            set;
        }
    }
}
