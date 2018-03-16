using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Week9Assignment
{
    /// <summary>
    /// This Class will Serialize and Deserialize using BinaryFormatter class.
    /// </summary>
 
    public class BinarySerialization
    {

        /// <summary>
        /// Serializes a collection using BinaryFormatter.
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
            BinaryFormatter formatter = new BinaryFormatter();

            using (var stream = File.Create(path))
            {
                formatter.Serialize(stream, list);
            }

            return list;
        }

        /// <summary>
        /// Deseializes a collection using BinaryFormatter.
        /// </summary>
        /// <param name="path">
        /// The path that will be derialized.
        /// </param>
        /// <returns>
        /// Returns list that gets derialized.
        /// </returns>
        public PersonList<Person> Deserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            PersonList<Person> deserializedList = null;

            using (var reader = File.OpenRead(path))
            {
                deserializedList = formatter.Deserialize(reader) as PersonList<Person>;

            }

            return deserializedList;
        }
    }
}
