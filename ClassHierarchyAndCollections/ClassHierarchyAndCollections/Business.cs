using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// This class inherits from Organization and holds two unique properties.
    /// One of those properties is a collection type List which contains Members.
    /// </summary>
    public class Business : Organization
    {
        public string MissionStatement
        {
            get;
            set;
        }

        public List<Member> Members
        {
            get;
            set;
        }
    }
}
