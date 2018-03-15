using System;
using System.IO;
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
            var serializer = new Week9JsonSerializer();
            var carmen = new Inkling("Carmen", InkColor.Orange);
            var spectral = new Inkling("Spectral", InkColor.Grape);
            var brooke = new Octoling("Brooke", InkColor.Raspberry);
            var tim = new Octoling("Tim", InkColor.Mustard);
            var team = new Team<Cephalokid>()
            {
                carmen,
                spectral,
                brooke,
                tim
            };

            serializer.Serialize(team, "testFile.txt");
            Assert.IsTrue(File.Exists("testFile.txt"));

            var deserializedTeam = serializer.Deserialize("testFile.txt");
            Assert.AreEqual(team, deserializedTeam);

            File.Delete("testFile.txt");
        }
    }
}
