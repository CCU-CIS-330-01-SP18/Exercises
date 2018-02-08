using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A generic class that inherits from Organization and holds the Client and Employee properties and GetLocation method.
    /// </summary>
    public class Business : Organization, ILocatable
    {
        public string Clients
        {
            get;
            set;
        }
        public string Employees
        {
            get;
            set;
        }

        private double longCoordinates;
        private double latCoordinates;
        double ILocatable.longLocatable()
        {
            return longCoordinates;
        }
        double ILocatable.latLocatable()
        {          
            return latCoordinates;
        }
        /// <summary>
        /// Returns a string of a location provided.
        /// </summary>
        /// <param name="myLocation"> A string passed through and returned. </param>
        /// <returns> Returns the myLocation string. </returns>
        public string GetLocation(string myLocation)
        {
            return myLocation;
        }
    }
}
