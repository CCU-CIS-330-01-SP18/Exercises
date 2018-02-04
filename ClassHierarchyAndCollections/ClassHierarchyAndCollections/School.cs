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
    public class School : Organization
    {
        public string Mascot
        {
            get;
            set;
        }

        public string Color
        {
            get;
            set;
        }
    }
}
