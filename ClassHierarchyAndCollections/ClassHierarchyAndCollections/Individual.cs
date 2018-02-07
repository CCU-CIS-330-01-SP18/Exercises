using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A generic class inherited from the Contact Class that contains the Age and Name properties.
    /// </summary>
    public class Individual : Contact
    {
        public int Age
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
    }
}
