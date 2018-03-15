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
    class Week9BinaryFormatter : ISerializer
    {
        /// <summary>
        /// Given a path to a file, deserializes an object contained in that file.
        /// </summary>
        /// <param name="serialized">A string containing the path to a file that contains a serialized object.</param>
        /// <returns>The deserialized object.</returns>
        public object Deserialize(string path)
        {
            var binaryFormatter = new BinaryFormatter();
            object deserialized;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Serial file not found.", path);
            }

            using (var file = File.OpenRead(path))
            {
                deserialized = binaryFormatter.Deserialize(file);
            }

            return deserialized;
        }

        /// <summary>
        /// Serializes this object, and puts the serialized object in a file.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="path">The path to the file that will hold the serialized object.</param>
        public void Serialize(object obj, string path)
        {
            var binaryFormatter = new BinaryFormatter();

            if (!File.Exists(path))
            {
                using (var file = File.Create(path))
                {
                    binaryFormatter.Serialize(file, obj);
                }
            }
            else
            {
                using (var file = File.OpenWrite(path))
                {
                    binaryFormatter.Serialize(file, obj);
                }
            }
        }
    }
}
