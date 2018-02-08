using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{

    /// <summary>
    /// Represents an Organization with a list of Members and the Focus of the Association.
    /// </summary>
    public class Association : Organization, IReadLists
    {
        public List<Member> Members { get; set; }
        public String Focus { get; set; }

        /// <summary>
        /// Prints each item in the list to the console. Implements IReadLists
        /// </summary>
        public void ReadList()
        {
            foreach(Member member in this.Members)
            {
                Console.WriteLine(member.DisplayName);
            }
        }
    }
}