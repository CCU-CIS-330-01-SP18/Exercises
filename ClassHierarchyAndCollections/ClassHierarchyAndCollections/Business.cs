using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A business with an annual profit or loss, an owner, and employees.
    /// </summary>
    public class Business : Organization, ICountableGroup
    {
        public int AnnualNetIncome { get; set; }
        
        public string OwnerName { get; set; }

        public List<Employee> Employees { get; set; }

        /// <summary>
        /// Gets the number of individuals in this organization.
        /// </summary>
        /// <returns>The number of specific individuals in this organization.</returns>
        public int GetGroupCount()
        {
            return Employees.Count;
        }
    }
}
