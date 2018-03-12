using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Week9CodingExercise
{
    /// <summary>
    /// Instantiates an object of type Customer that inherits from the Individual Class.
    /// </summary>
    [Serializable]

    [DataContract]
    public class Customer : Individual
    {
        /// <summary>
        /// Constructor that sets the name of the Customer.
        /// </summary>
        /// <param name="name">A name of the Customer, is set to null if nothing is supplied.</param>
        public Customer(string name = null)
            : base(name)
        {
        }
    }
}
