using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week9CodingExercise
{
    public class DataContract : ISerializer
    {
        static void DataContractSerialization<T>(IndividualList<T> list) where T : Individual
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(IndividualList<T>));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("_dc-individuals.xml", settings))
            {
                serializer.WriteObject(writer, list);
            }

            IndividualList<T> deserializedList = null;
            using (XmlReader reader = XmlReader.Create("_dc-individuals.xml"))
            {
                deserializedList = serializer.ReadObject(reader) as IndividualList<T>;
            }
        }

        public void Serialize(object o)
        {

        }

        public void Deserialize(object o)
        {

        }
    }
}
