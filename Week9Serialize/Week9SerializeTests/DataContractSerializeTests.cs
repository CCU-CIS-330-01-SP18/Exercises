using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KellermanSoftware.CompareNetObjects;
using Week9Serialization;

namespace Week9SerializeTests
{
    [TestClass]
    public class DataContractSerializeTests
    {
        [TestMethod]
        public void DataContractSerializeDeserialize()
        {
            var myFavoriteCereals = new CerealList { new CocoPuffs(), new FruityBites() };
            var dataContractSerializer = new DataContractSerialize();
            var comparer = new CompareLogic();

            string serializedCereal = dataContractSerializer.Serialize(myFavoriteCereals);
            var deserializedCereal = dataContractSerializer.Deserialize(serializedCereal);

            Assert.IsNotNull(serializedCereal);
            Assert.IsNotNull(deserializedCereal);
            Assert.IsTrue(deserializedCereal.GetType() == typeof(CerealList));
            Assert.IsTrue(comparer.Compare(myFavoriteCereals, deserializedCereal).AreEqual);
        }
    }
}
