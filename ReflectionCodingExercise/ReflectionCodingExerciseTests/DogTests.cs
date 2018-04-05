using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionCodingExercise;

namespace ReflectionCodingExerciseTests
{
    [TestClass]
    public class DogTests
    {
        [TestMethod]
        public void DogCanBeConstructed()
        {
            var Dog = typeof(Dog).GetConstructor(new Type[]{}).Invoke(null) as Dog;
            Assert.IsInstanceOfType(Dog, typeof(Dog));
        }

        [TestMethod]
        public void DogCanReadWrite()
        {
            var dog = new Dog();
            var dogType = typeof(Dog);
            var dogSpecies = dogType.GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
            var dogNumberOfLegs = dogType.GetProperty("Age", BindingFlags.Public | BindingFlags.Instance);

            // setting dogs value.
            dogSpecies.SetValue(dog, "Fluffy", null);
            dogNumberOfLegs.SetValue(dog, 16, null);

            // proving both dog properties can read and write.
            Assert.IsTrue(dogSpecies.CanRead);
            Assert.IsTrue(dogNumberOfLegs.CanRead);
            // proving setting the value worked as intended.
            Assert.AreEqual(dog.Name, "Fluffy");
            Assert.AreEqual(dog.Age, 16);
        }

        [TestMethod]
        public void DogMethodsCanBeCalled()
        {
            var Dog = new Dog();
            var getMethod = typeof(Dog).GetMethod("Bark", BindingFlags.Public | BindingFlags.Instance);
            var invokeMethod = getMethod.Invoke(Dog, null);

            Assert.AreEqual(Dog.Bark(), invokeMethod);
        }
    }
}