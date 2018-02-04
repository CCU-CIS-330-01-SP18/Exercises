using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Creates a Business object that derives from an Organization and implements the Ilocatable Interface.
    /// </summary>
    public class Business : Organization, ILocatable
    {
        private string location;
        public string BusinessEntity { get; set; }
        
        public int Sales { get; set; }
        
        // Sets a collection of Clients that can be used by the business class.
        public List<Client> Clients = new List<Client>();

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        /// <summary>
        /// Returns the location of a business.
        /// </summary>
        /// <param name="businessLocation">The location of a business passed as a string.</param>
        /// <returns>The location of the business.</returns>
        public string GetLocation(string businessLocation)
        {
            return businessLocation;
        }
    }

   

}
