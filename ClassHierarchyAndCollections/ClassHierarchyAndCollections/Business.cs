using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Provides the details of a business.
    /// </summary>
    class Business : Organization
    {
        public String BusinessOwner { get; set; }

        public Boolean IsOwnedByDisney { get; set; }

        public List<Client> Clients { get; set; }
    }
}
