using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using Newtonsoft.Json;


namespace Week9Serializations
{
    /// <summary>
    /// Serializes data into a JSON format.
    /// </summary>
    public class NewtonJsonSerialization : ISerializer
    {
        /// <summary>
        /// Serializes a device list into JSON.
        /// </summary>
        /// <param name="list">The list of devices.</param>
        public void Serialize(DeviceList<Device> list)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamWriter writer = File.CreateText("C:\\json_Devices.json"))
            {
                serializer.Serialize(writer, list);
            }
        }

        /// <summary>
        /// Diserializes list of devices from JSON.
        /// </summary>
        /// <returns>The list of devices.</returns>
        public DeviceList<Device> Deserialize()
        {
            JsonSerializer jsonSerialized = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            using (StreamReader stream = File.OpenText("C:\\json_Devices.json"))
            {
                return jsonSerialized.Deserialize(stream, typeof(DeviceList<Device>)) as DeviceList<Device>;
            }
        }
    }
}

