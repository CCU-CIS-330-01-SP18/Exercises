using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serialization;
using KellermanSoftware.CompareNetObjects;
using System.IO;


namespace Week9SerializationTests
{
    [TestClass]
    public class NewtonJsonSerilizationTests
    {
        [TestMethod]
        public void NewtonJsonSerilizationTest()
        {
            var list = new MarsupialList<Marsupial>
            {
                new TasmanianDevil("Taz") { NumberOfLegs = 4, Deadly = true , Adorable =false},
                new Quoll("Fluffy") { NumberOfLegs = 4, Deadly = true, Adorable=true }
            };

            var serializer = new NewtonJsonSerialization();
            serializer.Serialize(list);

            var file = new FileInfo("NewtonJson_Marsupials.json");
            Assert.IsTrue(file.Exists);

            MarsupialList<Marsupial> Logiclist = serializer.Deserialize();
            CompareLogic comparer = new CompareLogic();

            bool equalCompare = comparer.Compare(list, Logiclist).AreEqual;
            Assert.AreEqual(true, equalCompare);
        }
    }
}
