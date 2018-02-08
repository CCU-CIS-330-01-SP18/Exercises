using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Creates a Member object that derives from the Individual class.
    /// </summary>
    public class Member : Individual
    {
        public string MemberName { get; set; }

        public bool FeesDue { get; set; }
    }
}
