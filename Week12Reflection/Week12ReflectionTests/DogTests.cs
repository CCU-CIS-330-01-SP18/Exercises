using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Week12Reflection;

namespace Week12ReflectionTests
{
    [TestClass]
    public class DogTests
    {
        [TestMethod]
        public void CanConstructDog()
        {
            var dog = typeof(Dog).GetConstructor(new[] { typeof(int), typeof(int) }).Invoke(new object[] { 2, 3 });

            Assert.IsNotNull(dog);
            Assert.IsInstanceOfType(dog, typeof(Dog));
        }

        [TestMethod]
        public void CanGetSetDogFields()
        {
            var dog = typeof(Dog).GetConstructor(new[] { typeof(int), typeof(int) }).Invoke(new object[] { 2, 3 });
            var age = dog.GetType().GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
            var barkFactor = dog.GetType().GetField("barkFactor", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.AreEqual(2, age.GetValue(dog));
            Assert.AreEqual(3, barkFactor.GetValue(dog));

            age.SetValue(dog, 3);
            barkFactor.SetValue(dog, 5);

            Assert.AreEqual(3, age.GetValue(dog));
            Assert.AreEqual(5, barkFactor.GetValue(dog));
        }

        [TestMethod]
        public void CanBark()
        {
            var dog = typeof(Dog).GetConstructor(new[] { typeof(int), typeof(int) }).Invoke(new object[] { 2, 3 });
            var barkFactor = dog.GetType().GetField("barkFactor", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.AreEqual(3, barkFactor.GetValue(dog));

            dog.GetType().GetMethod("Bark", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(dog, null);

            Assert.AreEqual(4, barkFactor.GetValue(dog));
        }
    }
}
