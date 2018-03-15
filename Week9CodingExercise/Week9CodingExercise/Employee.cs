using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    /// <summary>
    /// Instantiates an object of type Employee which inherits from the object Individual.
    /// </summary>
    [Serializable]

    [DataContract]

    public class Employee : Individual
    {
        /// <summary>
        /// Constructor that sets the name of the Employee based on the property Name in Individual.
        /// </summary>
        /// <param name="name">The name of the Employee.</param>
        public Employee(string name = null)
            : base(name)
        {
        }
    }
}
