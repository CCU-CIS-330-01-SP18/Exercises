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
        public string GetLocation(string myLocation)
        {
            return myLocation;
        }
    }
}
