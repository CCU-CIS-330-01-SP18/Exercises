using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Week9_Serialization
{
    /// <summary>
    /// Serializes a GameLibrary list through Binary Serialization.
    /// </summary>
    public class BinarySerialization : ISerializer
    {
        /// <summary>
        /// Perform the serialization.
        /// </summary>
        /// <param name="library">The library list to serialize.</param>
        public void Serialize(GameLibrary<VideoGame> library)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream stream = File.Create("bin_Library.txt"))
            {
                bf.Serialize(stream, library);
            }
        }

        /// <summary>
        /// Perform the deserialization.
        /// </summary>
        /// <returns>The library list that was deserialized</returns>
        public GameLibrary<VideoGame> Deserialize()
        {
            BinaryFormatter bf = new BinaryFormatter();

            using(FileStream read = File.OpenRead("bin_Library.txt"))
            {
                return bf.Deserialize(read) as GameLibrary<VideoGame>;
            }
        }
    }
}
