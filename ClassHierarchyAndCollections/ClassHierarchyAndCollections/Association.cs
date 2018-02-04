using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Creates an Association Object and derives from the Organization class.
    /// </summary>
    public class Association : Organization, ILocatable
    {
        private string location;
        public string AssociationName { get; set; }

        public int AssociationFee { get; set; }

        public string Location { get; set; } 
        /// <summary>
        /// Retrieves the location of an association.
        /// </summary>
        /// <param name="associationLocation">String that contains the location of an association.</param>
        /// <returns>A string containing the location of an association.</returns>
        string GetLocation(string associationLocation)
        {
            return associationLocation;
        }
    }
}
