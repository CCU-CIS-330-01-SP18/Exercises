using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// This class inherits from Individual and holds two unique properties.
    /// </summary>
    public class Client : Individual
    {
        public int IdentificationNumber
        {
            get;
            set;
        }

        public string EmergencyContact
        {
            get;
            set;
        }
    }
}
