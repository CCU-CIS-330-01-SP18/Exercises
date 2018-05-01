using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Provides the ability to serialize and deserialize a weapon list.
    /// </summary>
    public class SerializeAndDeserialize
    {
        /// <summary>
        /// Serializes a list of data to the defined path.
        /// </summary>
        /// <param name="list">The list to be serialized.</param>
        /// <param name="path">The path to serialize the list to.</param>
        /// <returns>The list of data now serialized.</returns>
        public static WeaponList<Weapon> SerializeWeaponList(WeaponList<Weapon> list, string path)
        {
            // Serialize the weapon list.
            var format = new BinaryFormatSerializer();
            var serializedList = format.Serialize(list, path);

            return serializedList;
        }

        /// <summary>
        /// Deserializes a list of data located at the specified path.
        /// </summary>
        /// <param name="path">The path to retrieve the serializeed the list.</param>
        /// <returns>The list of data now deserialized.</returns>
        public static WeaponList<Weapon> DeserializeWeaponList(string path)
        {
            // Desrialize the weapon list.
            var format = new BinaryFormatSerializer();
            var deserializedList = format.Deserialize(path);

            return deserializedList;
        }
    }
}
