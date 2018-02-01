using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    public class Student : Individual
    {
        public int GradeClassification { get; set; }

        public double GPA { get; set; }

        public int ID { get; set; }
    }
}
