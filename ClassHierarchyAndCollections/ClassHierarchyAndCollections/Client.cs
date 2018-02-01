using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents a Client with a ContractStartDate and a ContractValue.
/// </summary>
namespace ClassHierarchyAndCollections
{
    public class Client : Individual
    {
        public DateTime ContractStartDate { get; set; }

        public decimal CotnractValue { get; set; }
    }
}
