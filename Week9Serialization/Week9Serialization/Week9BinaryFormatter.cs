using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Week9Serialization
{
    /// <summary>
    /// A class that can serialize and deserialize objects given to it, using the <see cref="BinaryFormatter"/> method.
    /// </summary>
    public class Week9BinaryFormatter : ISerializer
    {
        /// <summary>
        /// Given a path to a file, deserializes a <see cref="Team{T}"/> contained in that file.
        /// </summary>
        /// <param name="filePath">A string containing the path to a file that contains a serialized team.</param>
        /// <returns>The deserialized <see cref="Team{T}"/>.</returns>
        public Team<T> Deserialize<T>(string filePath) where T : Cephalokid
        {
            var binaryFormatter = new BinaryFormatter();
            var deserialized = new Team<T>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Serial file not found.", filePath);
            }

            using (var file = File.OpenRead(filePath))
            {
                deserialized = binaryFormatter.Deserialize(file) as Team<T>;
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
            var binaryFormatter = new BinaryFormatter();

            using (var file = File.OpenWrite(filePath))
            {
                binaryFormatter.Serialize(file, team);
            }
        }
    }
}
