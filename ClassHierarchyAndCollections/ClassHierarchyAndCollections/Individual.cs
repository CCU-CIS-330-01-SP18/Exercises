using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a Individual with a Name (String) and a Age (Int).
    /// </summary>
    public class Individual: Contact
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
