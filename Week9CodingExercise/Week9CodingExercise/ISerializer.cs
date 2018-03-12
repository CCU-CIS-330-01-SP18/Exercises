using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    /// <summary>
    /// Interface that defines two methods, serialize and deserialize.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Base method for serializing an object.
        /// </summary>
        /// <param name="list">IndividualList to be serialized.</param>
        void Serialize(IndividualList<Individual> list);

        /// <summary>
        /// Base method for deserializing an object.
        /// </summary>
        /// <param name="list">IndividualList to be deserialized.</param>
        /// <returns>An object.</returns>
        object Deserialize(IndividualList<Individual> list);
    }
}
