using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An association comprised of members with a scheduled meeting date and time.
    /// </summary>
    public class Association : Organization, ICountableGroup
    {
        public DateTime NextScheduledMeet { get; set; }
        
        public List<Member> Members { get; set; }

        /// <summary>
        /// Gets the number of individuals in this organization.
        /// </summary>
        /// <returns>The number of specific individuals in this organization.</returns>
        public int GetGroupCount()
        {
            return Members.Count;
        }
    }
}
