using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// This class inherits from Contact, holds two unique properties, and inherits an interface.
    /// </summary>
    public class Individual : Contact, IWork
    {
        public string PreferredName
        {
            get;
            set;
        }

        public string PreferredMethodOfContact
        {
            get;
            set;
        }

        /// <summary>
        /// This Method writes to the console utalizing an interface
        /// </summary>
        public void Work()
        {
            Console.WriteLine("I'm working.");
        }
    }
}
