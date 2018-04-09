using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12Reflection;
using System.Reflection;

namespace Week12ReflectionTests
{
    [TestClass]
    public class MemeTests
    {
        [TestMethod]
        public void CanConstructMeme()
        {
            var reflectionMeme = Activator.CreateInstance(typeof(Meme)) as Meme;

            Assert.IsInstanceOfType(reflectionMeme, typeof(Meme));
        }

        [TestMethod]
        public void MemeHasWorkingProperties()
        {
            var reflectionMeme = typeof(Meme);

            foreach(var property in reflectionMeme.GetProperties())
            {
                Assert.IsTrue(property.CanRead);
                Assert.IsTrue(property.CanWrite);
            }

            reflectionMeme.GetProperty("Title", BindingFlags.Public | BindingFlags.Instance).SetValue(reflectionMeme, "Dat Boi", null);
            reflectionMeme.GetProperty("HumorScore", BindingFlags.Public | BindingFlags.Instance).SetValue(reflectionMeme, 9, null);

            Assert.AreEqual("Dat Boi", reflectionMeme.GetProperty("Title", BindingFlags.Public | BindingFlags.Instance));
            //Assert.AreEqual(9, reflectionMeme.GetType().GetProperty("Title").GetValue(reflectionMeme, null));
        }

        [TestMethod]
        public void CanMakeMeLaugh()
        {
            var reflectionMeme = Activator.CreateInstance(typeof(Meme)) as Meme;

            var call = typeof(Meme).GetMethod("MakeMeLaugh", BindingFlags.Public | BindingFlags.Instance);
            var result = call.Invoke(reflectionMeme, null);

            Assert.AreEqual(reflectionMeme.MakeMeLaugh(), result);
        }
    }
}
