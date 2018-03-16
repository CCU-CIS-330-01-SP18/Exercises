using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Week9Serialization
{
    /// <summary>
    /// Creates a JsonSerializer that uses Newtonsoft that provides methods that serializes and deserializes Marsupial lists into a JSON format.
    /// </summary>
    public class NewtonJsonSerialization : ISerializer
    {
        /// <summary>
        /// Serializes a list of Marsupials into a JSON format.
        /// </summary>
        /// <param name="list">The list of Marsupials passed to be serialized.</param>
        public void Serialize(MarsupialList<Marsupial> list)
        {          
            JsonSerializer serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamWriter writer = File.CreateText("NewtonJson_Marsupials.json"))
            {
                serializer.Serialize(writer, list);
            }
        }

        /// <summary>
        /// Diserializes a list of Marsupials from a JSON format.
        /// </summary>
        /// <returns>The list that was deserialized.</returns>
        public MarsupialList<Marsupial> Deserialize()
        {
            JsonSerializer jsonSerialized = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamReader stream = File.OpenText("NewtonJson_Marsupials.json"))
            {
                return jsonSerialized.Deserialize(stream, typeof(MarsupialList<Marsupial>)) as MarsupialList<Marsupial>;
            }
        }
    }
}
