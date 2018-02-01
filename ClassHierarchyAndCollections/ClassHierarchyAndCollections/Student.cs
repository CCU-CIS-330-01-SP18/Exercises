using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents a Student with a GPA and ID. 
/// </summary>
namespace ClassHierarchyAndCollections
{
    public class Student : Individual
    {
        public int GradeClassification { get; set; }

        public double GPA { get; set; }

        public int ID { get; set; }
    }
}
