using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9Serializeation;
using KellermanSoftware.CompareNetObjects;

namespace Week9SerializationTests
{
    [TestClass]
    public class BinaryFormatSerializerTest
    {
        [TestMethod]
        public void Binary_Serialize_And_Deserialize_Are_Equal()
        {
            var format = new BinaryFormatSerializer();

            
            var list = new WeaponList<Weapon>();
            list.Add(new Sabre("Curvy") { Size = 3.0F });
            list.Add(new Halberd("Pointy") { Size = 7.5F });
            
            string path = "_Weapons.txt";
            
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
