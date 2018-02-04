using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{

    /// <summary>
    /// Represents a School with a list of Students and the Schools IsPrivate property.
    /// </summary>
    public class School : Organization
    {
        public List<Student> Students { get; set; }

        public bool IsPrivate { get; set; }
    }
}
