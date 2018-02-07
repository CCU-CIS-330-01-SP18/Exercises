using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A generic class that inherits from the Individual class and holds the unique StudentName and StudentAge properties.
    /// </summary>
    public class Student : Individual
    {
        public string StudentName
        {
            get;
            set;
        }
        public int StudentAge
        {
            get;
            set;
        }
    }
}
