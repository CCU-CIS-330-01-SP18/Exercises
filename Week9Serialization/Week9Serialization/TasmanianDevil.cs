using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a devilish animal that inherits from a Marsupial object.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TasmanianDevil : Marsupial
    {
        /// <summary>
        /// Contructs an object based on the parent Marsupial.
        /// </summary>
        /// <param name="name">Represents a name given to the TasmanianDevil.</param>
        public TasmanianDevil(string name = null)
            : base(name)
        {
        }
    }
}
