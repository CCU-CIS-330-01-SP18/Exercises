using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{

    /// <summary>
    /// Represents an Individual with an Age and a Name.
    /// </summary>
    public class Individual : Contact
    {
        public int Age { get; set; }

        public string Name { get; set; }
    }
}
