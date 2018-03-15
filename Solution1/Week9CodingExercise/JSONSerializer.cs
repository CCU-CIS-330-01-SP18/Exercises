using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week9CodingExercise
{
    /// <summary>
    /// Class that serializes and deserializes using Newtonsoft JSON Serialization.
    /// </summary>
    class JSONSerializer : ISerializer
    {
        /// <summary>
        /// Performs a serialization on a Roster of Action Characters.
        /// </summary>
        /// <param name="roster">The Roster of Action Characters.</param>
        public void Serialize(Roster<ActionCharacter> roster)
        {
            var jsonSerialzer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using(StreamWriter streamWriter = File.CreateText("roster_bin_json.json"))
            {
                jsonSerialzer.Serialize(streamWriter, roster);
            }
        }

        /// <summary>
        /// Performs a binary deserialization.
        /// </summary>
        /// <returns>The roster list that has been deserialaized.</returns>
        public Roster<ActionCharacter> Deserialize()
        {
            var jsonSerialzer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamReader streamWriter = File.OpenText("json_Library.json"))
            {
                return jsonSerialzer.Deserialize(streamWriter, typeof(Roster<ActionCharacter>)) as Roster<ActionCharacter>;
            }
        }
    }
}
