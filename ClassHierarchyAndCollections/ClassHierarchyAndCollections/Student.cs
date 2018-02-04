using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines a student contact.
    /// </summary>
    public class Student : Individual, IQuitable
    {
        public int StudentID { get; set; }

        public SchoolYear YearInSchool { get; set; }

        /// <summary>
        /// Implements the IQuitable interface to enable dropping out of school.
        /// </summary>
        public void Quit()
        {
            Console.WriteLine(this.DisplayName + " has decided to drop out of school.");
        }
    }
}
