using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents an Individual with an ID and a JoinDate.
/// </summary>
namespace ClassHierarchyAndCollections
{
    public class Member : Individual
    {
        public int ID { get; set; }

        public DateTime JoinDate { get; set; }
    }
}
