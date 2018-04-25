using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject;
using KellermanSoftware;
using KellermanSoftware.CompareNetObjects;

namespace FinalProjectTests
{
    [TestClass]
    public class SerializerAndDeserializerTest
    {
        [TestMethod]
        /// <summary>
        /// This method tests the SerializeAndDeserialize, BinaryFormatSerializer, Weapon, and WeaponList classes and ISerializer interface.
        /// </summary>
        public void CanSerializeAndDeserialize()
        {
            // Create the list to be serialized.
            var list = new WeaponList<Weapon>();
            list.Add(new Weapon() { Name = "Great Axe", Cost = 4.0M });
            list.Add(new Weapon() { Name = "Sabre", Cost = 3.0M });

            // Create the path the serialize the lis to.
            string path = "_WeaponListTestPath";

            var before = SerializeAndDeserialize.SerializeWeaponList(list, path);
            var after = SerializeAndDeserialize.DeserializeWeaponList(path);

            
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
