using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{

    /// <summary>
    /// Represents a Member with a 
    /// </summary>
    public class Member : Individual
    {
        public int ID { get; set; }
        public DateTime JoinDate { get; set; }
    }
}