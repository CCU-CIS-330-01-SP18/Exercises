using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9CodingExercise;
using KellermanSoftware.CompareNetObjects;
using System.Collections.Generic;
using System.IO;

namespace Week9CodingExerciseTests
{
    [TestClass]
    public class BinarySerializationTests
    {
        [TestMethod]
        public void BinarySerializationCanSerializeAndDeserialize()
        {
            var list = new IndividualList<Individual>();
            list.Add(new Employee("Ryan") { IsMale = true, Age = 24 });
            list.Add(new Customer("Taylor") { IsMale = false, Age = 21 });

            var serializer = new BinarySerializer();

            serializer.Serialize(list);

            var file = new FileInfo("b-individuals.txt");

            // Checks to see if the file exists after serialization.
            Assert.IsTrue(file.Exists);

            // The Deserialized List.
            object o = serializer.Deserialize(list);

            CompareLogic logic = new CompareLogic();

            // Checks to see if Instantiated List and Deserialized List Are Equal.
            bool areEqual = logic.Compare(list, o).AreEqual;

            Assert.AreEqual(true, areEqual);
        }
    }
}
