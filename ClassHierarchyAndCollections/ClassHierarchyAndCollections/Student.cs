using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Creates a Student object that derives from the Individual class.
    /// </summary>
    public class Student : Individual
    {
        public string StudentName { get; set; }

        public float GPA { get; set; }
    }
}
