using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A generic class inherited from the Organization class that contains the unique the SchoolName, SchoolLocation and Students properites.
    /// </summary>
    class School : Organization
    {
        public string SchoolName
        {
            get;
            set;
        }
        public List<Student> Students
        {
            get;
            set;
        }
        public string SchoolLocation
        {
            get;
            set;
        }
    }
}
