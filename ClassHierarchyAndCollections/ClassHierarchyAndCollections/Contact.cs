using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Creates a Contact object that also inherits an Ilocatable Interface.
    /// </summary>
    public class Contact : ILocatable
    {
        private string location;
        public string DisplayName { get; set; }

        public string LegalName { get; set; }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        /// <summary>
        /// Method as implemented in ILocatable for retrieving a location.
        /// </summary>
        /// <returns>Location of a Contact.</returns>
        public string GetLocation()
        {
            return location;
        }
    }
}
