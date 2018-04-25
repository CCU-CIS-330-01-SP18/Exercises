using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// A class which has the ability to serialize and deserialize collections using the BinaryFormatter class.
    /// </summary>
    public class BinaryFormatSerializer : ISerializer
    {
        /// <summary>
        /// Serializes a collection of Weapons in a WeaponList<> using BinaryFormatter.
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
            var formatter = new BinaryFormatter();

            using (var stream = File.Create(path))
            {
                formatter.Serialize(stream, list);
            }

            return list;
        }


        /// <summary>
        /// Deseializes the collection that was previously serialized by BinaryFormatter.
        /// </summary>
        /// <param name="path">
        /// The location where the collection was serialized.
        /// </param>
        /// <returns>
        /// The deserialized list so that you may run tests against this collection.
        /// </returns>
        public WeaponList<Weapon> Deserialize(string path)
        {
            var formatter = new BinaryFormatter();

            WeaponList<Weapon> deserializedList = null;

            using (var reader = File.OpenRead(path))
            {
                deserializedList = formatter.Deserialize(reader) as WeaponList<Weapon>;

            }

            return deserializedList;
        }
    }
}
