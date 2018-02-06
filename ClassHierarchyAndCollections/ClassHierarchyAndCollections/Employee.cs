using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// An individual with a job and an annual salary.
    /// </summary>
    public class Employee : Individual
    {
        public int AnnualSalary { get; set; }

        public string JobName { get; set; }
    }
}
