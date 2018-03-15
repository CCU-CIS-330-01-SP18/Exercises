using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Week9Serialization
{
    /// <summary>
    /// Serializes and Diserializes a list of Marsupials.
    /// </summary>
    public class BinarySerialization : ISerializer
    {
        /// <summary>
        /// Performs the serialization of a list of Marsupials.
        /// </summary>
        /// <param name="list">The list passed to be serialized.</param>
        public void Serialize(MarsupialList<Marsupial> list)
        {
            BinaryFormatter binaryFormat = new BinaryFormatter();
            using (FileStream stream = File.Create("binary_Marsupials.txt"))
            {
                binaryFormat.Serialize(stream, list);
            }
        }

        /// <summary>
        /// Performs the diserialization of a list of Marsupials.
        /// </summary>
        /// <returns>The Marsupial list that was deserialized</returns>
        public MarsupialList<Marsupial> Deserialize()
        {
            BinaryFormatter binaryFormat = new BinaryFormatter();

            using (FileStream read = File.OpenRead("binary_Marsupials.txt"))
            {
                return binaryFormat.Deserialize(read) as MarsupialList<Marsupial>;
            }
        }
    }
}
