using System.IO;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml;

namespace Week9Serialization
{
    /// <summary>
    /// A class that can serialize and deserialize objects given to it, using the <see cref="DataContractSerializer"/> method.
    /// </summary>
    public class Week9DataContractSerializer : ISerializer
    {
        private string xmlRegex = @"\.xml$";

        /// <summary>
        /// Given a path to a file, deserializes a <see cref="Team{T}"/> contained in that file.
        /// </summary>
        /// <param name="filePath">A string containing the path to a file that contains a serialized team.</param>
        /// <returns>The deserialized <see cref="Team{T}"/>.</returns>
        public Team<T> Deserialize<T>(string filePath) where T : Cephalokid
        {
            var serializer = new DataContractSerializer(typeof(Team<T>));
            var deserialized = new Team<T>();

            if (!File.Exists(filePath) || !Regex.IsMatch(filePath, xmlRegex))
            {
                throw new FileNotFoundException("Serial XML file not found.", filePath);
            }

            using (var file = XmlReader.Create(filePath))
            {
                deserialized = serializer.ReadObject(file) as Team<T>;
            }

            return deserialized;

        }

        /// <summary>
        /// Serializes this <see cref="Team{T}"/>, and puts the serialized team in a file.
        /// </summary>
        /// <param name="team">The <see cref="Team{T}"/> to serialize.</param>
        /// <param name="filePath">The path to the file that will hold the serialized team.</param>
        public void Serialize<T>(Team<T> team, string filePath) where T : Cephalokid
        {
            var serializer = new DataContractSerializer(typeof(Team<T>));
            var settings = new XmlWriterSettings() { Indent = true };

            if (!Regex.IsMatch(filePath, xmlRegex))
            {
                filePath += ".xml";
            }
            using (var file = XmlWriter.Create(filePath, settings))
            {
                serializer.WriteObject(file, team);
            }
        }
    }
}
