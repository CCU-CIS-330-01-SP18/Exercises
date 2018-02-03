using System.Collections.Generic;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an organization of contacts. Can contain multiple individuals.
    /// </summary>
    public class Organization : Contact
    {
        List<Individual> Members;

        /// <summary>
        /// Initializes a new instance of the Organization class.
        /// </summary>
        public Organization()
        {
            Members = new List<Individual>();
        }
    }
}
