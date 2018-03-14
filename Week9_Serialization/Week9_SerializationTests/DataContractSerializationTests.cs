using System;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9_Serialization;

namespace Week9_SerializationTests
{
    [TestClass]
    public class DataContractSerializationTests
    {
        [TestMethod]
        public void TestDataContractSerialization()
        {
            DataContractSerialization dcs = new DataContractSerialization();
            GameLibrary<VideoGame> library = new GameLibrary<VideoGame>();

            library.Add(new Platformer("Super Mario Bros."));
            library.Add(new Strategy("Grey Goo"));
            library.Add(new VideoGame("Overwatch"));
            dcs.Serialize(library);

            GameLibrary<VideoGame> library_ds = dcs.Deserialize();
            CompareLogic compare = new CompareLogic();

            Assert.IsTrue(compare.Compare(library, library_ds).AreEqual);
        }
    }
}