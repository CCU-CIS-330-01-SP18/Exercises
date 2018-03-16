using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KellermanSoftware.CompareNetObjects;
using Week9Serialization;

namespace Week9SerializeTests
{
    [TestClass]
    public class BinaryFormatTests
    {
        [TestMethod]
        public void BinarySerializeDeserialize()
        {
            var myFavoriteCereals = new CerealList { new CocoPuffs(), new FruityBites() };
            var binaryFormatter = new BinaryFormat();
            var comparer = new CompareLogic();

            string serializedCereal = binaryFormatter.Serialize(myFavoriteCereals);
            var deserializedCereal = binaryFormatter.Deserialize(serializedCereal);

            Assert.IsNotNull(serializedCereal);
            Assert.IsNotNull(deserializedCereal);
            Assert.IsTrue(deserializedCereal.GetType() == typeof(CerealList));
            Assert.IsTrue(comparer.Compare(myFavoriteCereals, deserializedCereal).AreEqual);
        }
    }
}
