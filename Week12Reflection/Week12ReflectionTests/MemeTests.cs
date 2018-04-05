using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12Reflection;

namespace Week12ReflectionTests
{
    [TestClass]
    public class MemeTests
    {
        [TestMethod]
        public void CanConstructMeme()
        {
            var reflectionMeme = Activator.CreateInstance(typeof(Meme)) as Meme;

            reflectionMeme.GetType
        }
    }
}
