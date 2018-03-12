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
            list.Add(new Employee("Ryan") { IsMale = true });
            list.Add(new Customer("Taylor") { IsMale = false });

            var newtonSerializer = new NewtonJsonSerializer();

            newtonSerializer.Serialize(list);

            FileInfo file = new FileInfo("nsj-individuals.json");

            Assert.IsTrue(file.Exists);

            var deserializedList = newtonSerializer.Deserialize(list);

            CompareLogic logic = new CompareLogic();

            bool areEqual = logic.Compare(list, deserializedList).AreEqual;

            Assert.AreEqual(true, areEqual);
        }
    }
}
