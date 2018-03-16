using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KellermanSoftware.CompareNetObjects;
using Week9Serialization;
using Newtonsoft.Json;

namespace Week9SerializeTests
{
    [TestClass]
    public class JsonSerializeTests
    {
        [TestMethod]
        public void JsonSerializeDeserialize()
        {
            var myFavoriteCereals = new CerealList { new CocoPuffs(), new FruityBites() };
            var jsonSerializer = new JsonSerialize();
            var comparer = new CompareLogic();

            string serializedCereal = jsonSerializer.Serialize(myFavoriteCereals);
            var deserializedCereal = jsonSerializer.Deserialize(serializedCereal);

            // Uncomment the below line to see the difference between the JSON results.
            //throw new Exception(JsonConvert.SerializeObject(deserializedCereal, typeof(CerealList), settings) + " VS " + serializedCereal.ToString());

            Assert.IsNotNull(serializedCereal);
            Assert.IsNotNull(deserializedCereal);
            Assert.IsTrue(deserializedCereal.GetType() == typeof(CerealList));
            Assert.AreEqual(myFavoriteCereals, deserializedCereal);

            // Even though Week9Serialization.CerealList and Week9Serialization.CerealList are the same, AreEqual 
            // fails along with the CompareNetObjects comparison.

            //Assert.IsTrue(comparer.Compare(myFavoriteCereals, deserializedCereal).AreEqual);
        }
    }
}
