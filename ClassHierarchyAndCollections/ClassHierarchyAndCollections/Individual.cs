using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Creates an Individual object that derives from the Contact class.
    /// </summary>
    public class Individual : Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
