using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{   
    /// <summary>
    /// Provides the details of a student.
    /// </summary>
    public class Student: Individual, IBookLunchDate
    {
        public Decimal StudentGradePointAverage { get; set; }

        public String StudentSchool { get; set; }

        /// <summary>
        /// Books a lunch date with the specified student.
        /// </summary>
        public void BookLunchDate()
        {
            Console.WriteLine("You have booked a lunch date with: " + this.DisplayName);
        }
    }
}
