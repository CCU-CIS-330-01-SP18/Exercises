using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week9Serializeation
{
    /// <summary>
    /// A class which has the ability to serialize and deserialize collections using the DataContractSerializer class.
    /// </summary>
    public class DataContractFormatSerializer : ISerializer
    {
        /// <summary>
        /// Serializes a collection of Weapons in a WeaponList<> using DataContractSerializer.
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
            var serializer = new DataContractSerializer(typeof(WeaponList<Weapon>));

            var settings = new XmlWriterSettings() { Indent = true };

            using (var writer = XmlWriter.Create(path, settings))
            {
                serializer.WriteObject(writer, list);
            }

            return list;
        }

        /// <summary>
        /// Deseializes the collection that was previously serialized by DataContractSerializer.
        /// </summary>
        /// <param name="path">
        /// The location where the collection was serialized.
        /// </param>
        /// <returns>
        /// The deserialized list so that you may run tests against this collection.
        /// </returns>
        public WeaponList<Weapon> Deserialize(string path)
        {
            var serializer = new DataContractSerializer(typeof(WeaponList<Weapon>));

            // The reason why var is not used here is because you cannot set a var field to null.
            WeaponList<Weapon> deserializedList = null;

            using (var reader = XmlReader.Create(path))
            {
                deserializedList = serializer.ReadObject(reader) as WeaponList<Weapon>;
            }

            return deserializedList;
        }
    }
}
