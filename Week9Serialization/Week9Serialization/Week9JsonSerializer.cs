using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// A class that can serialize and deserialize objects given to it, using the <see cref="JsonSerializer"/> method.
    /// </summary>
    public class Week9JsonSerializer : ISerializer
    {
        /// <summary>
        /// Given a path to a file, deserializes a team contained in that file.
        /// </summary>
        /// <param name="filePath">A string containing the path to a file that contains a serialized team.</param>
        /// <returns>The deserialized team.</returns>
        public Team<T> Deserialize<T>(string filePath) where T : Cephalokid
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            Team<T> deserialized = null;

            if (!File.Exists(filePath) || !Regex.IsMatch(filePath, @"\.json$"))
            {
                throw new FileNotFoundException("Serial JSON file not found.", filePath);
            }

            using (var file = File.OpenText(filePath))
            {
                deserialized = serializer.Deserialize(file, typeof(Team<T>)) as Team<T>;
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
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            if (!Regex.IsMatch(filePath, @"\.json$"))
            {
                filePath += ".json";
            }
            using (var file = File.CreateText(filePath))
            {
                serializer.Serialize(file, team);
            }
        }
    }
}
