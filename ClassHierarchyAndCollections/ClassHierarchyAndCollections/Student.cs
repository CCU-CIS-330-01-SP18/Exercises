using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a Student with a StudentID (Int) and a StudentGPA (Float).
    /// </summary>
    public class Student: Individual
    {
        public int StudentID { get; set; }
        public float StudentGPA { get; set; }
    }
}
