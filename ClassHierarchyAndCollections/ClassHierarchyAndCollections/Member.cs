using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An individual that belongs to an association, can spend time contributing to it, and has a role within it.
    /// </summary>
    public class Member : Individual
    {
        public int ContributedHours { get; set; }

        public string RoleName { get; set; }
    }
}
