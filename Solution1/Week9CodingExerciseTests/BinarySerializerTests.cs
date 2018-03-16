using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9CodingExercise;
using System.Runtime.Serialization.Formatters.Binary;
using KellermanSoftware.CompareNetObjects;


namespace Week9CodingExerciseTests
{
    [TestClass]
    public class BinarySerializerTests
    {
        [TestMethod]
        public void BinarySerializationTests()
        {
            BinarySerializer binarySerializer = new BinarySerializer();
            Roster<ActionCharacter> roster = new Roster<ActionCharacter>();

            var batman = new Hero("Batman");
            var joker = new Villan("The Joker");
            var alfred = new ActionCharacter("Alfred Pennyworth");

            roster.Add(batman);
            roster.Add(joker);
            roster.Add(alfred);
            binarySerializer.Serialize(roster);

            Roster<ActionCharacter> deserializedRoster = binarySerializer.Deserialize();
            CompareLogic comparison = new CompareLogic();

            Assert.IsTrue(comparison.Compare(roster, deserializedRoster).AreEqual);
        }
    }
}
