using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serialization;
using KellermanSoftware.CompareNetObjects;
using System.Collections.Generic;
using System.IO;


namespace Week9SerializationTests
{
    [TestClass]
    public class BinarySerializationTests
    {
        [TestMethod]
        public void BinarySerializationTest()
        {
            var list = new MarsupialList<Marsupial>
            {
                new TasmanianDevil("Taz") { NumberOfLegs = 4, Deadly = true , Adorable =false},
                new Quoll("Fluffy") { NumberOfLegs = 4, Deadly = true, Adorable=true }
            };

            var serializer = new BinarySerialization();
            serializer.Serialize(list);

            var file = new FileInfo("binary_Marsupials.txt");
            Assert.IsTrue(file.Exists);

            MarsupialList<Marsupial> Binarylist = serializer.Deserialize();
            CompareLogic comparer = new CompareLogic();

            bool equalCompare = comparer.Compare(list, Binarylist).AreEqual;
            Assert.AreEqual(true, equalCompare);
        }
    }
}
