using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Assignment;
using KellermanSoftware.CompareNetObjects;

namespace Week9AssignmentTests
{
    [TestClass]
    public class BinarySerializationTests
    {
        [TestMethod]
        public void BinaryTest()
        {
            var format = new BinarySerialization();


            var list = new PersonList<Person>();
            list.Add(new Male("Justin") { Age = 22 });
            list.Add(new Female("Nicole") { Age = 18 });

            string path = "_Persons.txt";

            var before = format.Serialize(list, path);
            var after = format.Deserialize(path);

            ComparisonConfig config = null;
            CompareLogic comparer = new CompareLogic();
            if (config != null)
            {
                comparer.Config = config;
            }

            var compareResult = comparer.Compare(before, after);

            Assert.IsTrue(compareResult.AreEqual);
        }
    }
}
