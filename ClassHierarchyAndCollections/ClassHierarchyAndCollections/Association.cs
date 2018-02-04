using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines an Association: an organized group of members created for the benefit of said members.
    /// </summary>
    class Association : Organization
    {
        public int AnnualDues { get; set; }

        public DateTime DueDate { get; set; }

        public List<Member> Members { get; }
    }
}
