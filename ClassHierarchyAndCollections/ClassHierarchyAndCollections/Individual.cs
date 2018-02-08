using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Provides the details of an individual.
    /// </summary>
    class Individual : Contact
    {
        public String PhoneNumber { get; set; }

        public String MarritalStatus { get; set; }
    }
}
