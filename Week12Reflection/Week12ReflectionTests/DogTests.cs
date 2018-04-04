using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Linq;
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
        public void CanGetSetDogProperties()
        {
            var dog = typeof(Dog).GetConstructor(new[] { typeof(int), typeof(int) }).Invoke(new object[] { 2, 3 });

        }
    }
}
