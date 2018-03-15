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
        /// Given a path to a file, deserializes a team contained in that file.
        /// </summary>
        /// <param name="filePath">A string containing the path to a file that contains a serialized team.</param>
        /// <returns>The deserialized team.</returns>
        public Team<T> Deserialize<T>(string filePath) where T : Cephalokid
        {
            var binaryFormatter = new BinaryFormatter();
            Team<T> deserialized = null;

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
        /// Serializes this team, and puts the serialized team in a file.
        /// </summary>
        /// <param name="team">The team to serialize.</param>
        /// <param name="filePath">The path to the file that will hold the serialized team.</param>
        public void Serialize<T>(Team<T> team, string filePath) where T : Cephalokid
        {
            var binaryFormatter = new BinaryFormatter();

            //if (!File.Exists(filePath))
            //{
            //    using (var file = File.Create(filePath))
            //    {
            //        binaryFormatter.Serialize(file, team);
            //    }
            //}
            //else
            //{
                using (var file = File.OpenWrite(filePath))
                {
                    binaryFormatter.Serialize(file, team);
                }
            //}
        }
    }
}
