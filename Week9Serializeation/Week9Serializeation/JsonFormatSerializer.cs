using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serializeation
{
    /// <summary>
    /// A class which has the ability to serialize and deserialize collections using the JsonSerializer class.
    /// </summary>
    public class JsonFormatSerializer : ISerializer
    {
        /// <summary>
        /// Serializes a collection of Weapons in a WeaponList<> using JsonSerializer.
        /// </summary>
        /// <param name="list">
        /// The collection to be serialized.
        /// </param>
        /// <param name="path">
        /// The path to serialize to.
        /// </param>
        /// <returns>
        /// The list that will be serialized so that you may run tests against this collection.
        /// </returns>
        public WeaponList<Weapon> Serialize(WeaponList<Weapon> list, string path)
        {
            var serializer = new JsonSerializer
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
        /// Deseializes the collection that was previously serialized by JsonSerializer.
        /// </summary>
        /// <param name="path">
        /// The location where the collection was serialized.
        /// </param>
        /// <returns>
        /// The deserialized list so that you may run tests against this collection.
        /// </returns>
        public WeaponList<Weapon> Deserialize(string path)
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            // The reason why var is not used here is because you cannot set a var field to null.
            WeaponList<Weapon> deserializedList = null;

            using (var reader = File.OpenText(path))
            {
                deserializedList = serializer.Deserialize(reader, typeof(WeaponList<Weapon>)) as WeaponList<Weapon>;
            }

            return deserializedList;
        }
    }
}
