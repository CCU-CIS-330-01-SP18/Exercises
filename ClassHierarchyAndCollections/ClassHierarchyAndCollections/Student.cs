using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    class Student: Individual
    {
        public Decimal StudentGradePointAverage { get; set; }

        public String StudentSchool { get; set; }
    }
}
