using System;
using System.IO;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serialization;

namespace Week9SerializationTests
{
    [TestClass]
    public class Week9JsonSerializerTests
    {
        [TestMethod]
        public void JsonSerializerCanSerialize()
        {
            string fileName = "testFile.json";
            var serializer = new Week9JsonSerializer();
            var carmen = new Inkling("Carmen", InkColor.Orange);
            var spectral = new Inkling("Spectral", InkColor.Grape);
            var brooke = new Octoling("Brooke", InkColor.Raspberry);
            var tim = new Octoling("Tim", InkColor.Mustard);
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
    }
}
