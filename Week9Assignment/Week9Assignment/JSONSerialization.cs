using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Assignment
{
    /// <summary>
    /// This Class will Serialize and Deserialize using JSONSerilization class.
    /// </summary>
    
    public class JSONSerialization: Iserializer
    {
        /// <summary>
        /// Serializes a collection using JSONSerilization.
        /// </summary>
        /// <param name="list">
        /// The collection that will be serialized.
        /// </param>
        /// <param name="path">
        /// The path that will be serialized.
        /// </param>
        /// <returns>
        /// Returns list that gets serialized.
        /// </returns>

        public PersonList<Person> Serialize(PersonList<Person> list, string path)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (var writer = File.CreateText(path))
            {
                serializer.Serialize(writer, list);
            }

            return list;
        }

        /// <summary>
        /// Serializes a collection using JSONSerilization.
        /// </summary>
        /// <param name="list">
        /// The collection that will be serialized.
        /// </param>
        /// <param name="path">
        /// The path that will be serialized.
        /// </param>
        /// <returns>
        /// Returns list that gets serialized.
        /// </returns>

        public PersonList<Person> Deserialize(string path)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            PersonList<Person> deserializedList = null;

            using (var reader = File.OpenText(path))
            {
                deserializedList = serializer.Deserialize(reader, typeof(PersonList<Person>)) as PersonList<Person>;
            }

            return deserializedList;
        }
    }
}
