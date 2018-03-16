using System;
using System.Linq;
using System.Text;


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
        /// <returns>An object made from diserializing a list.</returns>
        MarsupialList<Marsupial> Deserialize();

    }
}
