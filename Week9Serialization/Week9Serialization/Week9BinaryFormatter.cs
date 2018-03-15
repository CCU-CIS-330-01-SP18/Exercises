using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// A class that can serialize and deserialize objects given to it, using the <see cref="BinaryFormatter"/> method.
    /// </summary>
    public class Week9BinaryFormatter : ISerializer
    {
        /// <summary>
        /// Given a path to a file, deserializes an object contained in that file.
        /// </summary>
        /// <param name="serialized">A string containing the path to a file that contains a serialized object.</param>
        /// <returns>The deserialized object.</returns>
        public object Deserialize(string filePath)
        {
            var binaryFormatter = new BinaryFormatter();
            object deserialized = null;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Serial file not found.", filePath);
            }

            using (var file = File.OpenRead(filePath))
            {
                deserialized = binaryFormatter.Deserialize(file);
            }

            return deserialized;
        }

        /// <summary>
        /// Serializes this object, and puts the serialized object in a file.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="filePath">The path to the file that will hold the serialized object.</param>
        public void Serialize(object obj, string filePath)
        {
            var binaryFormatter = new BinaryFormatter();

            if (!File.Exists(filePath))
            {
                using (var file = File.Create(filePath))
                {
                    binaryFormatter.Serialize(file, obj);
                }
            }
            else
            {
                using (var file = File.OpenWrite(filePath))
                {
                    binaryFormatter.Serialize(file, obj);
                }
            }
        }
    }
}
