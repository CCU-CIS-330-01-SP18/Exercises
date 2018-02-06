using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// This class is the top of the class hierarchy and holds the FullName and ContactNumber properties.
    /// </summary>
    public class Contact
    {
        public string FullName
        {
            get;
            set;
        }
        public int ContactNumber
        {
            get;
            set;
        }
    }
}
