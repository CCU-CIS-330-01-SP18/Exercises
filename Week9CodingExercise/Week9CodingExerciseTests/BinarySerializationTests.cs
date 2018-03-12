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
            list.Add(new Employee("Ryan") { IsMale = true });
            list.Add(new Customer("Taylor") { IsMale = false });

            var serializer = new BinarySerializer();

            serializer.Serialize(list);

            FileInfo file = new FileInfo("b-individuals.txt");

            Assert.IsTrue(file.Exists);

            object o = serializer.Deserialize(list);

            CompareLogic logic = new CompareLogic();

            bool areEqual = logic.Compare(list, o).AreEqual;

            Assert.AreEqual(true, areEqual);
        }
    }
}
