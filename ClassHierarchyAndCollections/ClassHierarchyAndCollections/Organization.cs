using System.Collections.Generic;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an organization of individuals.
    /// </summary>
    public class Organization : Contact
    {
        protected List<Individual> roster;

        public string Motto { get; set; }
        public List<Individual> Roster
        {
            get
            {
                // Since lists are reference types, make a new copy of it to return.
                // This way, the roster cannot be directly modified by those who read it.
                List<Individual> rosterCopy = new List<Individual>();
                foreach (Individual individual in roster)
                {
                    rosterCopy.Add(individual);
                }
                return rosterCopy;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Organization class.
        /// </summary>
        public Organization()
        {
            
        }
    }
}
