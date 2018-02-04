using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{

    /// <summary>
    /// Represents a Business with a list of Clients and the PrimaryService of the Business.
    /// </summary>
    public class Business : Organization
    {
        public List<Client> Clients { get; set; }

        public String PrimaryService { get; set; }
    }
}
