using System;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9CodingExercise;

namespace Week9CodingExerciseTests
{
    [TestClass]
    public class DataContractSerializerTests
    {
        [TestMethod]
        public void DataContractSerializerTest()
        {
            DataContractSerialization dataContractSerializer = new DataContractSerialization();
            Roster<ActionCharacter> roster = new Roster<ActionCharacter>();

            var batman = new Hero("Batman");
            var joker = new Villan("The Joker");
            var alfred = new ActionCharacter("Alfred Pennyworth");

            roster.Add(batman);
            roster.Add(joker);
            roster.Add(alfred);
            dataContractSerializer.Serialize(roster);

            Roster<ActionCharacter> deserializedRoster = dataContractSerializer.Deserialize();
            CompareLogic compare = new CompareLogic();

            Assert.IsTrue(compare.Compare(roster, deserializedRoster).AreEqual);
        }
    }
}
