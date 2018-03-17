using System;
using System.IO;
using System.Linq;
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

            var serializer = new BinaryFormatting();
            serializer.Serialize(deviceList);

            //var file = new FileInfo("b_Devices.txt");
            //Assert.IsTrue(file.Exists);

            DeviceList<Device> list = serializer.Deserialize();

            Assert.IsTrue(list[0].Equals(deviceList[0]));
            Assert.IsTrue(list[1].Equals(deviceList[1]));
        }
    }
}
