using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Week9Serialization
{
    /// <summary>
    /// A class that can serialize and deserialize objects given to it, using the <see cref="DataContractSerializer"/> method.
    /// </summary>
    public class Week9DataContractSerializer : ISerializer
    {
        /// <summary>
        /// Given a path to a file, deserializes an object contained in that file.
        /// </summary>
        /// <param name="serialized">A string containing the path to a file that contains a serialized object.</param>
        /// <returns>The deserialized object.</returns>
        public object Deserialize(string filePath)
        {
            var serializer = new DataContractSerializer(typeof(object));
            object deserialized = null;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Serial file not found.", filePath);
            }

            using (var file = XmlReader.Create(filePath))
            {
                deserialized = serializer.ReadObject(file) as object;
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
            var serializer = new DataContractSerializer(typeof(object));
            var settings = new XmlWriterSettings() { Indent = true };
            using (var file = XmlWriter.Create(filePath))
            {
                serializer.WriteObject(file, obj);
            }
        }
    }
}
