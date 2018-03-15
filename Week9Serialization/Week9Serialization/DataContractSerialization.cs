using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Week9Serialization
{
    /// <summary>
    /// Serialize and deserialize methods using DataContractSerializer and require a list of Marsupials passed to it.
    /// </summary>
    public class DataContractSerialization: ISerializer
    {
        /// <summary>
        /// Performs the serialization using the DataContract of a list of Marsupials.
        /// </summary>
        /// <param name="list">A Marsupial list passed to be serialized.</param>
        public void Serialize(MarsupialList<Marsupial> list)
        {
            DataContractSerializer dataSerializer = new DataContractSerializer(typeof(MarsupialList<Marsupial>));

            XmlWriterSettings xmls = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("dataContract_Marsupials.xml", xmls))
            {
                dataSerializer.WriteObject(writer, list);
            }
        }

        /// <summary>
        /// Performs the diserialization of a list of Marsupials using DataContract.
        /// </summary>
        /// <returns>The list that was deserialized</returns>
        public MarsupialList<Marsupial> Deserialize()
        {
            DataContractSerializer dataSerializer = new DataContractSerializer(typeof(MarsupialList<Marsupial>));

            using (XmlReader reader = XmlReader.Create("dataContract_Marsupials.xml"))
            {
                return dataSerializer.ReadObject(reader) as MarsupialList<Marsupial>;
            }
        }
    }
}
