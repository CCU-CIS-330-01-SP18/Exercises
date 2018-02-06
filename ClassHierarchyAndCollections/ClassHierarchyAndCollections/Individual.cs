using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A singular person with an email address and a cell phone number.
    /// </summary>
    public class Individual : Contact
    {
        public string EmailAddress { get; set; }

        public string CellNumber { get; set; }
    }
}
