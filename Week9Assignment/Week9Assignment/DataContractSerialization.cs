using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week9Assignment
{
    /// <summary>
    /// This Class will Serialize and Deserialize using DataContract class.
    /// </summary>
    
    public class DataContractSerialization: Iserializer
    {
        /// <summary>
        /// Serializes a collection using DataContract.
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
            DataContractSerializer serializer = new DataContractSerializer(typeof(PersonList<Person>));

            var settings = new XmlWriterSettings() { Indent = true };

            using (var writer = XmlWriter.Create(path, settings))
            {
                serializer.WriteObject(writer, list);
            }

            return list;
        }

        /// <summary>
        /// Serializes a collection using DataContract.
        /// </summary>
        /// <param name="list">
        /// The collection that will be derialized.
        /// </param>
        /// <param name="path">
        /// The path that will be derialized.
        /// </param>
        /// <returns>
        /// Returns list that gets derialized.
        /// </returns>
        
        public PersonList<Person> Deserialize(string path)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(PersonList<Person>));

            PersonList<Person> deserializedList = null;

            using (var reader = XmlReader.Create(path))
            {
                deserializedList = serializer.ReadObject(reader) as PersonList<Person>;
            }

            return deserializedList;
        }
    }
}
