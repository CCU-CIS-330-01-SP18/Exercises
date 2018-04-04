using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12ReflectionCodingExercise;

namespace Week12ReflectionCodingExerciseTests
{
    [TestClass]
    public class DogTests
    {
        [TestMethod]
        public void CanConstructADog()
        {
            var dog = typeof(Dog).GetConstructor(new Type[] { }).Invoke(null) as Dog;

            Assert.IsInstanceOfType(dog, typeof(Dog));
        }

        [TestMethod]
        public void CanInvokeDogMethod()
        {
            var dog = new Dog();

            var dogMethod = dog.GetType().GetMethod("DogToHumanYears", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int) }, null);
            int result = (int)dogMethod.Invoke(dog, new object[] { 4 });

            Assert.AreEqual(28, result);
        }

        [TestMethod]
        public void CanReadDogProperties()
        {
            var d = typeof(Dog);

            var dog = new Dog { Name = "Maggie", Age = 1 };

            Assert.AreEqual("Maggie", d.GetProperty("Name", BindingFlags.Public | BindingFlags.Instance).GetValue(dog));
            Assert.AreEqual(1, d.GetProperty("Age", BindingFlags.Public | BindingFlags.Instance).GetValue(dog));
        }

        [TestMethod]
        public void CanSetDogProperties()
        {
            var dog = new Dog();
            string name = "Hershey";
            int age = 9;
            var nameInfo = dog.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
            nameInfo.SetValue(dog, name, null);

            var ageInfo = dog.GetType().GetProperty("Age", BindingFlags.Public | BindingFlags.Instance);
            ageInfo.SetValue(dog, age, null);

            Assert.AreEqual("Hershey", dog.Name);
            Assert.AreEqual(9, dog.Age);
        }
    }
}
