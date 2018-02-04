using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// This class inherits from Organization and holds two unique properties.
    /// </summary>
    public class Association : Organization
    {
        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }
    }
}
