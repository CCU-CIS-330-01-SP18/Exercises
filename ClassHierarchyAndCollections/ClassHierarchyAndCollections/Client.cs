using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a Client with a ClientService (String) and a LengthOfBeingClient (Int).
    /// </summary>
    public class Client: Individual
    {
        public string ClientService { get; set; }
        public int LengthOfBeingClient { get; set; }
    }
}
