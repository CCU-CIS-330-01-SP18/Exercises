using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace Week9Serialization
{
    /// <summary>
    /// Serializes data via the Data Contract method.
    /// </summary>
    class DataContractSerialization: ISerializer
    {
        /// <summary>
        /// Serializes a list of devices via the data contract method.
        /// </summary>
        /// <param name="list">A list of devices</param>
        public void Serialize(DeviceList<Device> list)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DeviceList<Device>));

            XmlWriterSettings xmls = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("_dc-devices.xml"))
            {
                serializer.WriteObject(writer, list);
            }
        }

        /// <summary>
        /// Deserializes a list of devices via the data contract method.
        /// </summary>
        /// <returns>The list of devices.</returns>
        public DeviceList<Device> Deserialize()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DeviceList<Device>));

            using (XmlReader reader = XmlReader.Create("_dc-devices.xml"))
            {
                return serializer.ReadObject(reader) as DeviceList<Device>;
            }
        }
    }
}
