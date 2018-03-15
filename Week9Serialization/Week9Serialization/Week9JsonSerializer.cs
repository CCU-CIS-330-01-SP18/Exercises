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
        /// Given a path to a file, deserializes an object contained in that file.
        /// </summary>
        /// <param name="serialized">A string containing the path to a file that contains a serialized object.</param>
        /// <returns>The deserialized object.</returns>
        public object Deserialize(string filePath)
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            object deserialized = null;

            if (!File.Exists(filePath) || !Regex.IsMatch(filePath, @"\.json$"))
            {
                throw new FileNotFoundException("Serial JSON file not found.", filePath);
            }

            using (var file = File.OpenText(filePath))
            {
                deserialized = serializer.Deserialize(file, typeof(object));
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
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            if (Regex.IsMatch(filePath, @"\.json$"))
            {
                using (var file = File.CreateText(filePath))
                {
                    serializer.Serialize(file, obj);
                }
            }
            else
            {
                using (var file = File.CreateText(filePath + ".json"))
                {
                    serializer.Serialize(file, obj);
                }
            }
        }

        /*
         * JsonSerializer serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamWriter writer = File.CreateText("_nsj-animals.json"))
            {
                serializer.Serialize(writer, list);
            }

            AnimalList<T> deserializedList = null;
            using (StreamReader reader = File.OpenText("_nsj-animals.json"))
            {
                deserializedList = serializer.Deserialize(reader, typeof(AnimalList<T>)) as AnimalList<T>;
            }
            */
    }
}
