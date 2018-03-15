using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9CodingExercise;
using KellermanSoftware.CompareNetObjects;
using System.IO;

namespace Week9CodingExerciseTests
{
    [TestClass]
    public class NewtonJsonSerializerTests
    {
        [TestMethod]
        public void NewtonJsonSerializerCanSerializeAndDeserialize()
        {
            var list = new IndividualList<Individual>();
            list.Add(new Employee("Ryan") { IsMale = true, Age = 24 });
            list.Add(new Customer("Taylor") { IsMale = false, Age = 21 });

            var newtonSerializer = new NewtonJsonSerializer();

            newtonSerializer.Serialize(list);

            var file = new FileInfo("nsj-individuals.json");

            // Checks to see if the file exists after serialization.
            Assert.IsTrue(file.Exists);

            // The Deserialized List.
            var deserializedList = newtonSerializer.Deserialize(list);

            CompareLogic logic = new CompareLogic();

            bool areEqual = logic.Compare(list, deserializedList).AreEqual;

            // Checks to see if Instantiated List and Deserialized List Are Equal.
            Assert.AreEqual(true, areEqual);
        }
    }
}
