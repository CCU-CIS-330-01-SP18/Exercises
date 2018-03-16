using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serializations;

namespace Week9SerializationTests
{
    [TestClass]
    public class NewtonJsonSerilizationTests
    {
        [TestMethod]
        public void NewtonJsonSerilizationTest()
        {
            var list = new DeviceList<Device>
            {
               new Computer(),
                new MobilePhone()
            };

            var serializer = new NewtonJsonSerialization();
            serializer.Serialize(list);

            var file = new FileInfo("C:\\newtonjson_Devices.json");
            Assert.IsTrue(file.Exists);

            DeviceList<Device> deviceList = serializer.Deserialize();
            
            Assert.AreEqual(list, deviceList);
        }
    }
}
