using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Week12Reflection;

namespace Week12ReflectionTests
{
    [TestClass]
    public class CatTests
    {
        [TestMethod]
        public void CanConstructCat()
        {
            var cat = typeof(Cat).GetConstructor(new[] { typeof(int) }).Invoke(new object[] { 2 });
            Assert.IsNotNull(cat);
            Assert.IsInstanceOfType(cat, typeof(Cat));
        }
    }
}
