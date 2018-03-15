using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a cute cuddly creature that could rip your face off, and is inherited from a Marsupial.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Quoll : Marsupial
    {
        /// <summary>
        /// Constructs an object based of the parent object of Marsupial.
        /// </summary>
        /// <param name="name">The name provided to the little creature.</param>
        public Quoll(string name = null)
            : base(name)
        {
        }
    }
}
