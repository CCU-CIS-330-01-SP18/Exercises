using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An individual that belongs to an academic institution, takes courses there, and specializes in a certan field.
    /// </summary>
    public class Student : Individual
    {
        public int TotalCourseCredits { get; set; }

        public string CurrentMajor { get; set; }
    }
}
