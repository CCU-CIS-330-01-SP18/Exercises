using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a Member with a MemberName (String) and a MemberID (Int).
    /// </summary>
    public class Member: Individual
    {
        public string MemberName { get; set; }
        public int MemberID { get; set; }
    }
}
