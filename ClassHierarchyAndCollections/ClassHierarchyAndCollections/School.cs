using System.Collections.Generic;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a school, which can have a class of students and a catalog of courses.
    /// </summary>
    public class School : Organization
    {
        Dictionary<string, int> CourseCatalog { get; set; }
        List<Student> DeansList { get; set; }

        /// <summary>
        /// Initializes a new instance of the School class.
        /// </summary>
        public School() : base()
        {
            CourseCatalog = new Dictionary<string, int>();
            DeansList = new List<Student>();
        }

        /// <summary>
        /// Decide which students go on the Dean's List this semester, and update the List with the findings.
        /// </summary>
        public void CalculateDeansList()
        {
            DeansList.Clear();
            foreach (Student student in Roster)
            {
                if (student.GPA >= 3.5)
                {
                    DeansList.Add(student);
                }
            }
        }

        /// <summary>
        /// Teaches the given course to all students enrolled at the school. Adds the given course's stress level to each student.
        /// </summary>
        /// <param name="courseName">The name of the course to teach.</param>
        /// <remarks>At our schools, you learn what WE want you to learn.</remarks>
        public void TeachCourse(string courseName)
        {
            if (CourseCatalog.ContainsKey(courseName))
            {
                foreach (Student student in Roster)
                {
                    student.Study(CourseCatalog[courseName]);
                }
            }
        }
    }
}
