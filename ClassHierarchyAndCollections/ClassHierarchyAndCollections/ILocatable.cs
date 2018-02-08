using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Interface that is meant to be added on to objects that have a location.
    /// </summary>
    public interface ILocatable
    {
        string Location
        {
            get;
            set;
        }

        /// <summary>
        /// This method returns a location.
        /// </summary>
        /// <returns>A location in the form of a string.</returns>
        string GetLocation();
    }
}
