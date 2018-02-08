using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Creates a Client object that derives from the Individual class.
    /// </summary>
    public class Client : Individual
    {
        public string ClientName { get; set; }

        public string ClientIndustry { get; set; }
    }
}
