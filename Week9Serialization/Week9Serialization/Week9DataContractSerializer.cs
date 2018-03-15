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
        /// Given a path to a file, deserializes a team contained in that file.
        /// </summary>
        /// <param name="filePath">A string containing the path to a file that contains a serialized team.</param>
        /// <returns>The deserialized team.</returns>
        public Team<T> Deserialize<T>(string filePath) where T : Cephalokid
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

            return (Team<T>) deserialized;

        }

        /// <summary>
        /// Serializes this team, and puts the serialized team in a file.
        /// </summary>
        /// <param name="team">The team to serialize.</param>
        /// <param name="filePath">The path to the file that will hold the serialized team.</param>
        public void Serialize<T>(Team<T> team, string filePath) where T : Cephalokid
        {
            var serializer = new DataContractSerializer(typeof(object));
            var settings = new XmlWriterSettings() { Indent = true };
            using (var file = XmlWriter.Create(filePath))
            {
                serializer.WriteObject(file, team);
            }
        }
    }
}
