using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A school with a tuition rate, students, and the possibility for a football team.
    /// </summary>
    public class School : Organization, ICountableGroup
    {
        public int SemiannualTuition { get; set; }

        public bool HasFootballTeam { get; set; }

        public List<Student> Students { get; set; }

        /// <summary>
        /// Gets the number of individuals in this organization.
        /// </summary>
        /// <returns>The number of specific individuals in this organization.</returns>
        public int GetGroupCount()
        {
            return Students.Count;
        }
    }
}
