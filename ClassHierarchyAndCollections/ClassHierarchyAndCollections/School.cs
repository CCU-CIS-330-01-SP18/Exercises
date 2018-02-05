using System.Collections.Generic;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a school, which can have a roster of <see cref="Student"/>s and a catalog of courses.
    /// </summary>
    public class School : Organization
    {
        private List<Student> deansList;
        public Dictionary<string, int> CourseCatalog { get; set; }
        public List<Student> DeansList
        {
            get
            {
                return deansList;
            }
        }

        /// <summary>
        /// Initializes a new instance of the School class.
        /// </summary>
        public School() : base()
        {
            CourseCatalog = new Dictionary<string, int>();
            deansList = new List<Student>();
        }

        /// <summary>
        /// Decides which <see cref="Student"/>s go on the Dean's List this semester, and updates the <see cref="DeansList"/> with the findings.
        /// </summary>
        public void CalculateDeansList()
        {
            deansList.Clear();
            foreach (Student student in Roster)
            {
                if (student.GPA >= 3.5)
                {
                    deansList.Add(student);
                }
            }
        }

        /// <summary>
        /// Teaches the given course to all <see cref="Student"/>s enrolled at the school.
        /// </summary>
        /// <param name="courseName">The name of the course to teach.</param>
        /// <returns>Whether or not the class was taught.
        /// If no such class exists in the catalog, or no students exist to take the class, it will return false.</returns>
        /// <remarks>At our schools, you learn what we want you to learn. Freedom is slavery.</remarks>
        public bool TeachCourse(string courseName)
        {
            if (CourseCatalog.ContainsKey(courseName) && Roster.Count > 0)
            {
                foreach (Student student in Roster)
                {
                    student.Study(CourseCatalog[courseName]);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
