using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a Association with a AssociationName (String) and a MemberCount (Int).
    /// </summary>
    public class Association: Organization
    {
        public string AssociationName { get; set; }
        public int MemberCount { get; set; }
    }
}
