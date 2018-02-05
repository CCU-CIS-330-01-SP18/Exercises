using System;
using System.Collections.Generic;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an organization of <see cref="Individual"/>s.
    /// </summary>
    public class Organization : Contact
    {
        public string Motto { get; set; }
        public DateTime FoundingDate { get; set; }
        public List<Individual> Roster { get; set; }

        /// <summary>
        /// Initializes a new instance of the Organization class.
        /// </summary>
        public Organization()
        {
            Roster = new List<Individual>();
        }
    }
}
