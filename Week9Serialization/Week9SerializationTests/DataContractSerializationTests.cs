using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serializations;

namespace Week9SerializationTests
{
    [TestClass]
    public class DataContractSerializationTests
    {
        [TestMethod]
        public void DataContractTest()
        {
            var list = new DeviceList<Device>
            {
                new Computer(),
                new MobilePhone()
            };

            var serializer = new DataContractSerialization();
            serializer.Serialize(list);

            var file = new FileInfo("C:\\dctrct-devices.xml");
            Assert.IsTrue(file.Exists);

            DeviceList<Device> DeviceList = serializer.Deserialize();

            Assert.AreEqual(list, DeviceList);
        }
    }
}
