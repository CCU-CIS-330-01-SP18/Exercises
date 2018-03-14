using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week9_Serialization
{
    /// <summary>
    /// Serializes a GameLibrary list through Newtonsoft JSON Serialization.
    /// </summary>
    public class JSONSerialization : ISerializer
    {
        /// <summary>
        /// Perform the serialization.
        /// </summary>
        /// <param name="library">The library list to serialize.</param>
        public void Serialize(GameLibrary<VideoGame> library)
        {
            JsonSerializer jsons = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamWriter sw = File.CreateText("json_Library.json"))
            {
                jsons.Serialize(sw, library);
            }
        }

        /// <summary>
        /// Perform the deserialization.
        /// </summary>
        /// <returns>The library list that was deserialized</returns>
        public GameLibrary<VideoGame> Deserialize()
        {
            JsonSerializer jsons = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamReader sr = File.OpenText("json_Library.json"))
            {
                return jsons.Deserialize(sr, typeof(GameLibrary<VideoGame>)) as GameLibrary<VideoGame>;
            }
        }
    }
}
