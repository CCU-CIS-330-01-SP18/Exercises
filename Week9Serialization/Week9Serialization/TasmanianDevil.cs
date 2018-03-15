using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a devilish animal that inherits from a Marsupial.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TasmanianDevil : Marsupial
    {
        /// <summary>
        /// Contructs a devil based on the parent Marsupial.
        /// </summary>
        /// <param name="name">Represents a name given to the Tasmanian Devil.</param>
        public TasmanianDevil(string name = null)
            : base(name)
        {
        }
    }
}
