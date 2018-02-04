using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{

    /// <summary>
    /// Represents a Student with a GPA, Grade Classificiation and ID. 
    /// </summary>
    public class Student : Individual
    {
        public int GradeClassification { get; set; }

        public double GPA { get; set; }

        public int ID { get; set; }
    }
}
