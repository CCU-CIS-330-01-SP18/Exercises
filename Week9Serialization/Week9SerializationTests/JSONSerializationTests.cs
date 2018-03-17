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

            DeviceList<Device> deviceList = serializer.Deserialize();

            Assert.IsTrue(list[0].Equals(deviceList[0]));
            Assert.IsTrue(list[1].Equals(deviceList[1]));
        }
    }
}
