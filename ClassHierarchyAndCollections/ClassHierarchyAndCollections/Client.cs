using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    public class Client : Individual
    {
        public DateTime ContractStartDate { get; set; }

        public decimal CotnractValue { get; set; }
    }
}
