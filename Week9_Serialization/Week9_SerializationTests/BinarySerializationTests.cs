using System;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9_Serialization;

namespace Week9_SerializationTests
{
    [TestClass]
    public class BinarySerializationTests
    {
        [TestMethod]
        public void TestBinarySerialization()
        {
            BinarySerialization bs = new BinarySerialization();
            GameLibrary<VideoGame> library = new GameLibrary<VideoGame>();

            library.Add(new Platformer("MegaMan X"));
            library.Add(new Strategy("Plague, Inc."));
            library.Add(new VideoGame("Farming Simulator"));
            bs.Serialize(library);

            GameLibrary<VideoGame> library_ds = bs.Deserialize();
            CompareLogic compare = new CompareLogic();

            Assert.IsTrue(compare.Compare(library, library_ds).AreEqual);
        }
    }
}