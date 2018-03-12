using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week9CodingExercise
{
    /// <summary>
    /// Instantiates a DataContract which serializes and deserializes an Individual List into XML Format.
    /// </summary>
    public class DataContract : ISerializer
    {
        /// <summary>
        /// Method that takes an IndividualList and Serializes it into XML.
        /// </summary>
        /// <typeparam name="T">Of Type Individual.</typeparam>
        /// <param name="list">An IndividualList to serialize.</param>
        static void DataContractSerialization<T>(IndividualList<T> list) where T : Individual
        {
            var serializer = new DataContractSerializer(typeof(IndividualList<T>));

            var settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("_dc-individuals.xml", settings))
            {
                serializer.WriteObject(writer, list);
            }  
        }

        /// <summary>
        /// Method that Deserializes an IndividualList from XML.
        /// </summary>
        /// <typeparam name="T">Of Type Individual.</typeparam>
        /// <param name="list">An IndividualList passed in to be deserialized.</param>
        /// <returns></returns>
        static object DataContractDeserialization<T>(IndividualList<T> list) where T : Individual
        {
            var serializer = new DataContractSerializer(typeof(IndividualList<T>));

            IndividualList<T> deserializedList = null;
            using (XmlReader reader = XmlReader.Create("_dc-individuals.xml"))
            {
                deserializedList = serializer.ReadObject(reader) as IndividualList<T>;
            }

            return deserializedList;
        }

        /// <summary>
        /// Abstracted method to serialize an IndividualList Can call this instead of
        /// DataContract.DataContractSerialization.
        /// </summary>
        /// <param name="individualList">An IndividualList to be serialized.</param>
        public void Serialize(IndividualList<Individual> individualList)
        {
            DataContract.DataContractSerialization(individualList);
        }

        /// <summary>
        /// Abstracted method to deserialize an IndividualList instead of using 
        /// DataContract.DataContractDeserialization.
        /// </summary>
        /// <param name="individualList">An IndividualList to be deserialized.</param>
        /// <returns></returns>
        public object Deserialize(IndividualList<Individual> individualList)
        {
            return DataContract.DataContractDeserialization(individualList);
        }
    }
}
