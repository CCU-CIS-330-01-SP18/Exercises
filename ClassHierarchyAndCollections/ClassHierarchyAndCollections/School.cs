using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Creates a School object that derives from the Organization class and can use the ILocatable Interface.
    /// </summary>
    public class School : Organization, ILocatable
    {
        private string location;
        public string SchoolName { get; set; }

        public bool IsPublic { get; set; }

        string Location
        {
            get { return location; }
            set { location = value; }
        }
        /// <summary>
        /// Returns the location of a School.
        /// </summary>
        /// <param name="schoolLocation">The location of a school passed as a string.</param>
        /// <returns>Returns the location of a school.</returns>
        string GetLocation(string schoolLocation)
        {
            return schoolLocation;
        }
    }
}
