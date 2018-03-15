using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9CodingExercise;
using KellermanSoftware.CompareNetObjects;
using System.IO;

namespace Week9CodingExerciseTests
{
    [TestClass]
    public class DataContractTests
    {
        [TestMethod]
        public void DataContractCanSerializeAndDeserialize()
        {
            var list = new IndividualList<Individual>();
            list.Add(new Employee("Ryan") { IsMale = true, Age = 24 });
            list.Add(new Customer("Taylor") { IsMale = false, Age = 21 });

            var dataContract = new DataContract();

            dataContract.Serialize(list);

            var file = new FileInfo("_dc-individuals.xml");

            // Checks to see if the file exists after serialization.
            Assert.IsTrue(file.Exists);

            // The Deserialized List.
            var deserializedList = dataContract.Deserialize(list);

            CompareLogic logic = new CompareLogic();
            
            bool areEqual = logic.Compare(list, deserializedList).AreEqual;

            // Checks to see if Instantiated List and Deserialized List Are Equal.
            Assert.AreEqual(true, areEqual);
        }
    }
}
