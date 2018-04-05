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

        [TestMethod]
        public void CanGetSetCatFields()
        {
            var cat = typeof(Cat).GetConstructor(new[] { typeof(int) }).Invoke(new object[] { 2 });
            var age = cat.GetType().GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
            var clawLength = cat.GetType().GetField("clawLength", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.AreEqual(2, age.GetValue(cat));
            Assert.AreEqual(1.0f, clawLength.GetValue(cat));

            age.SetValue(cat, 3);
            clawLength.SetValue(cat, 0.5f);

            Assert.AreEqual(3, age.GetValue(cat));
            Assert.AreEqual(0.5f, clawLength.GetValue(cat));
        }

        [TestMethod]
        public void CanScratch()
        {
            var cat = typeof(Cat).GetConstructor(new[] { typeof(int) }).Invoke(new object[] { 2 });
            var clawLength = cat.GetType().GetField("clawLength", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.AreEqual(1.0f, clawLength.GetValue(cat));

            cat.GetType().GetMethod("Scratch", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(cat, null);

            Assert.AreEqual(0.9f, clawLength.GetValue(cat));
        }
    }
}
