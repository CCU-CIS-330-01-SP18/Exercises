using System;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9_Serialization;

namespace Week9_SerializationTests
{
    [TestClass]
    public class JSONSerializationTests
    {
        [TestMethod]
        public void TestJSONSerialization()
        {
            JSONSerialization js = new JSONSerialization();
            GameLibrary<VideoGame> library = new GameLibrary<VideoGame>();

            library.Add(new Platformer("Super Mario Odyssey"));
            library.Add(new Strategy("Fortnite"));
            library.Add(new VideoGame("Assassin's Creed"));
            js.Serialize(library);

            GameLibrary<VideoGame> library_ds = js.Deserialize();
            CompareLogic compare = new CompareLogic();

            Assert.IsTrue(compare.Compare(library, library_ds).AreEqual);
        }
    }
}
