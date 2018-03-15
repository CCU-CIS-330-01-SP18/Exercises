using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serialization;
using KellermanSoftware.CompareNetObjects;
using System.IO;

namespace Week9SerializationTests
{
    [TestClass]
    public class DataContractSerializationTests
    {
        [TestMethod]
        public void DataContractTest()
        {
            var list = new MarsupialList<Marsupial>
            {
                new TasmanianDevil("Taz") { NumberOfLegs = 4, Deadly = true , Adorable =false},
                new Quoll("Fluffy") { NumberOfLegs = 4, Deadly = true, Adorable=true }
            };

            var serializer = new DataContractSerialization();
            serializer.Serialize(list);

            var file = new FileInfo("dataContract_Marsupials.xml");
            Assert.IsTrue(file.Exists);

            MarsupialList<Marsupial> Logiclist = serializer.Deserialize();
            CompareLogic comparer = new CompareLogic();

            bool equalCompare = comparer.Compare(list, Logiclist).AreEqual;

            Assert.AreEqual(true, equalCompare);
        }
    }
}