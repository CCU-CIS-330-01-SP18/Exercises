using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// This class inherits from Contact and holds two unique properties.
    /// </summary>
    public class Organization : Contact
    {
        public string Address
        {
            get;
            set;
        }

        public int ZipCode
        {
            get;
            set;
        }

    }
}
