using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Provides the details of a business client.
    /// </summary>
    class Client: Individual
    {
        public String ClientBusiness { get; set; }

        public String ClientCreditStanding { get; set; }
    }
}
