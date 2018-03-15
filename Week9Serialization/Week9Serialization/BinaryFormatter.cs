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
        static void BinarySerialization<T>(DeviceList<Device> list) where T : Device
        {
            //Console.WriteLine(deserializedList.Equals(list));
        }

        public DeviceList<Device> Deserialize(FileStream reader)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (System.IO.FileStream stream = File.Create("_Devices.txt"))
            {
                return formatter.Serialize(stream, list);
            }
        }

        public void Serialize(FileStream stream, DeviceList<Device> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            DeviceList<Device> deserializedList = null;
            using (FileStream reader = File.OpenRead("_Devices.txt"))
            {
                deserializedList = formatter.Deserialize(reader) as DeviceList<Device>;
            }
        }
    }
}
