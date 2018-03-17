using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Week9Serialization
{
    /// <summary>
    /// Serializes data in the Binary format.
    /// </summary>
    class BinaryFormatter: ISerializer
    {
        /// <summary>
        /// Serializes a device list into binary format.
        /// </summary>
        /// <param name="list">A list of devices.</param>
        public void Serialize(DeviceList<Device> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (System.IO.FileStream stream = File.Create("_Devices.txt"))
            {
                formatter.Serialize(list);
            }
        }

        /// <summary>
        /// Deserializes a list of devices from binary format.
        /// </summary>
        /// <returns>The list of devices.</returns>
        public DeviceList<Device> Deserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream read = File.OpenRead("_Devices.txt"))
            {
                return formatter.Deserialize() as DeviceList<Device>;
            }
        }

        
    }
}
