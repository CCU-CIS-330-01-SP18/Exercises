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
    class Business : Organization, ILocatable
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
        int ILocatable.yLocatable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int ILocatable.xLocatable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       
        /// <summary>
        /// Takes a string parameter and ILocatable objects to return myLocation.
        /// </summary>
        /// <param name="myLocation"> A string parameter used to find location. </param>
        /// <param name="xLocatable"> An interface parameter that is used to find location. </param>
        /// <param name="ylocatable"> An interface parameter that is used to find part of the location. </param>
        /// <returns>Returns the string myLocation. </returns>
        public string GetLocation(string myLocation, ILocatable xLocatable, ILocatable ylocatable)
        {
            return myLocation;
        }
    }
}
