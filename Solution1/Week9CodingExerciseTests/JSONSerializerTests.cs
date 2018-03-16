using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KellermanSoftware.CompareNetObjects;
using Week9CodingExercise;
using Newtonsoft.Json;

namespace Week9CodingExerciseTests
{
    [TestClass]
    public class JSONSerializerTests
    {
        [TestMethod]
        public void JSONSerializerTest()
        {
            JSONSerialization jSONSerializer = new JSONSerialization();
            Roster<ActionCharacter> roster = new Roster<ActionCharacter>();

            var batman = new Hero("Batman");
            var joker = new Villan("The Joker");
            var alfred = new ActionCharacter("Alfred Pennyworth");

            roster.Add(batman);
            roster.Add(joker);
            roster.Add(alfred);
            jSONSerializer.Serialize(roster);

            Roster<ActionCharacter> deserializedRoster = jSONSerializer.Deserialize();
            CompareLogic comparison = new CompareLogic();

            Assert.IsTrue(comparison.Compare(roster, deserializedRoster).AreEqual);
        }

    }
}
