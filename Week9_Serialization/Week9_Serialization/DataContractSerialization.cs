using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace Week9_Serialization
{
    /// <summary>
    /// Serializes a GameLibrary list through DataContract Serialization.
    /// </summary>
    public class DataContractSerialization : ISerializer
    {
        /// <summary>
        /// Perform the serialization.
        /// </summary>
        /// <param name="library">The library list to serialize.</param>
        public void Serialize(GameLibrary<VideoGame> library)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(GameLibrary<VideoGame>));

            XmlWriterSettings xmls = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("dc_Library.xml", xmls))
            {
                dcs.WriteObject(writer, library);
            }
        }

        /// <summary>
        /// Perform the deserialization.
        /// </summary>
        /// <returns>The library list that was deserialized</returns>
        public GameLibrary<VideoGame> Deserialize()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(GameLibrary<VideoGame>));

            using (XmlReader reader = XmlReader.Create("dc_Library.xml"))
            {
                return dcs.ReadObject(reader) as GameLibrary<VideoGame>;
            }
        }
    }
}
