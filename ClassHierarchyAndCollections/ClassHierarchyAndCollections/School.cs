using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    public class School: Organization, IStudentCountable
    {
        public string SchoolName { get; set; }
        public List<Student> Students { get; set;}


        public int GetStudentCount()
        {
            return Students.Count;
        }

    }
}
