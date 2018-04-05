using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Week12Reflection;

namespace Week12ReflectionTests
{
    [TestClass]
    public class GIFTests
    {
        [TestMethod]
        public void CanConstructGIF()
        {
            var reflectionGIF = Activator.CreateInstance(typeof(GIF)) as GIF;

            Assert.IsInstanceOfType(reflectionGIF, typeof(GIF));
        }

        [TestMethod]
        public void GIFHasWorkingProperties()
        {
            var reflectionGIF = typeof(GIF);

            foreach (var property in reflectionGIF.GetProperties())
            {
                Assert.IsTrue(property.CanRead);
                Assert.IsTrue(property.CanWrite);
            }

            reflectionGIF.GetProperty("Title", BindingFlags.Public | BindingFlags.Instance).SetValue(reflectionGIF, "Screaming Toad", null);
            reflectionGIF.GetProperty("HumorScore", BindingFlags.Public | BindingFlags.Instance).SetValue(reflectionGIF, 10, null);

            Assert.AreEqual("Screaming Toad", reflectionGIF.GetProperty("Title", BindingFlags.Public | BindingFlags.Instance));
            //Assert.AreEqual(10, reflectionMeme.GetType().GetProperty("Title").GetValue(reflectionMeme, null));
        }

        [TestMethod]
        public void CanMakeMeLaugh()
        {
            var reflectionGIF = Activator.CreateInstance(typeof(GIF)) as GIF;

            var call = typeof(GIF).GetMethod("MakeMeLaugh", BindingFlags.Public | BindingFlags.Instance);
            var result = call.Invoke(reflectionGIF, null);

            Assert.AreEqual(reflectionGIF.MakeMeLaugh(), result);
        }
    }
}
