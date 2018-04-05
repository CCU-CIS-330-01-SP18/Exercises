using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionCodingExercise;

namespace ReflectionCodingExerciseTests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void AnimalCanBeConstructed()
        {
            var animal = typeof(Animal).GetConstructor(new Type[] { }).Invoke(null) as Animal;
            Assert.IsInstanceOfType(animal, typeof(Animal));
        }

        [TestMethod]
        public void AnimalCanReadWrite()
        {           
            var animal = new Animal();
            var animalType = typeof(Animal);
            var animalSpecies = animalType.GetProperty("Species", BindingFlags.Public | BindingFlags.Instance);
            var animalNumberOfLegs = animalType.GetProperty("NumberOfLegs", BindingFlags.Public | BindingFlags.Instance);

            // setting animals value.
            animalSpecies.SetValue(animal, "Canine", null);
            animalNumberOfLegs.SetValue(animal, 4, null);

            // proving both animal properties can read and write.
            Assert.IsTrue(animalType.GetProperty("Species", BindingFlags.Public | BindingFlags.Instance).CanRead);
            Assert.IsTrue(animalType.GetProperty("NumberOfLegs", BindingFlags.Public | BindingFlags.Instance).CanRead);
            // proving setting the value worked as intended.
            Assert.AreEqual(animal.Species, "Canine");
            Assert.AreEqual(animal.NumberOfLegs, 4);
        }

        [TestMethod]
        public void AnimalMethodsCanBeCalled()
        {
            var animal = new Animal();
            var getMethod = typeof(Animal).GetMethod("IsAlive", BindingFlags.Public | BindingFlags.Instance);
            var invokeMethod = getMethod.Invoke(animal, null);

            Assert.AreEqual(animal.IsAlive(), invokeMethod);
        }
    }
}
