using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// An interface that defines the Serialize and Deserialize methods.
    /// </summary>
    interface ISerializer
    {
        /// <summary>
        /// The base method for serializing an object.
        /// </summary>
        /// <param name="list">The MarsupialList to be serialized.</param>       
        void Serialize(MarsupialList<Marsupial> list);

        /// <summary>
        /// The base method for diserializing an object.
        /// </summary>
        /// <returns>An object derived from diserializing a list.</returns>
        MarsupialList<Marsupial> Deserialize();

    }
}
