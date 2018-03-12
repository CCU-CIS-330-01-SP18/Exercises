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
            list.Add(new Employee("Ryan") { IsMale = true });
            list.Add(new Customer("Taylor") { IsMale = false });

            var dataContract = new DataContract();

            dataContract.Serialize(list);

            FileInfo file = new FileInfo("_dc-individuals.xml");

            Assert.IsTrue(file.Exists);

            var deserializedList = dataContract.Deserialize(list);

            CompareLogic logic = new CompareLogic();
            
            bool areEqual = logic.Compare(list, deserializedList).AreEqual;

            Assert.AreEqual(true, areEqual);
        }
    }
}
