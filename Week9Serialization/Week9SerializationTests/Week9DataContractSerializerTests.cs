using System;
using System.IO;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serialization;

namespace Week9SerializationTests
{
    [TestClass]
    public class Week9DataContractSerializerTests
    {
        [TestMethod]
        public void DataContractCanSerialize()
        {
            string fileName = "testFile.xml";
            var serializer = new Week9DataContractSerializer();
            var carmen = new Inkling("Carmen", "Orange");
            var spectral = new Inkling("Spectral", "Grape");
            var brooke = new Octoling("Brooke", "Magenta");
            var tim = new Octoling("Tim", "Yellow");
            carmen.ShopForGear();
            spectral.ShopForGear();
            tim.Sanitize();
            var team = new Team<Cephalokid>()
            {
                carmen,
                spectral,
                brooke,
                tim
            };

            serializer.Serialize(team, fileName);
            Assert.IsTrue(File.Exists(fileName), "File not found.");

            var deserializedTeam = serializer.Deserialize<Cephalokid>(fileName);

            CompareLogic comparer = new CompareLogic();
            var compareResult = comparer.Compare(team, deserializedTeam);

            Assert.IsTrue(compareResult.AreEqual, "Objects not equal: " + compareResult.DifferencesString);

            File.Delete(fileName);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void DataContractThrowsNotFound()
        {
            var serializer = new Week9DataContractSerializer();
            var deserializeNonexistent = serializer.Deserialize<Cephalokid>("portal3.xml");
        }
    }
}
