using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// This class is the top tier in the hierarchy, and holds two unique properties.
    /// </summary>
    public class Contact
    {
        public string DisplayName
        {
            get;
            set;
        }
        public string LegalName
        {
            get;
            set;
        }
    }
}
