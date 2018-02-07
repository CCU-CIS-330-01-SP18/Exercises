using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A generic class inherited from the Individual class and holds the unique UserID and UserName properties. 
    /// </summary>
    public class Client : Individual
    {
        public string UserID
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
    }
}
