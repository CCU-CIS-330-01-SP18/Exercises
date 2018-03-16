using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serializations;

namespace Week9SerializationTests
{
    [TestClass]
    public class BinarySerializationTests
    {
        [TestMethod]
        public void BinarySerializationTest()
        {
            DeviceList<Device> deviceList = new DeviceList<Device>
            {
                new Computer(),
                new MobilePhone()
            };

            var serializer = new BinaryFormatter();
            serializer.Serialize(deviceList);

            var file = new FileInfo("C:\\b_Devices.txt");
            Assert.IsTrue(file.Exists);

            DeviceList<Device> list = serializer.Deserialize();

            Assert.AreEqual(deviceList, list);
        }
    }
}
