using System;
using System.IO;
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

            serializer.Serialize(team, fileName);
            Assert.IsTrue(File.Exists(fileName), "File not found.");

            var deserializedTeam = serializer.Deserialize(fileName);
            Assert.IsTrue(KellermanSoftware.CompareNetObjects.CompareLogic.Equals(team, deserializedTeam), "Objects not equal.");

            File.Delete(fileName);
        }
    }
}
