using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Week12Reflection;

namespace Week12ReflectionTests
{
    [TestClass]
    public class HolyHandGrenadeTests
    {
        [TestMethod]
        public void HolyHandGrenadeCanBeConstructed()
        {
            // Reflected object.
            var hhg_reflected = Activator.CreateInstance(typeof(HolyHandGrenade)) as HolyHandGrenade;

            // Standard object (for testing)
            var hhg_standard = new HolyHandGrenade();

            Assert.IsInstanceOfType(hhg_reflected, typeof(HolyHandGrenade));
            Assert.AreEqual(hhg_reflected.GetVerseFromBible(), hhg_standard.GetVerseFromBible());
        }

        [TestMethod]
        public void HolyHandGrenadeHasWorkingProperties()
        {
            // Reflected object.
            var hhg_reflected = typeof(HolyHandGrenade);
            
            // For each property, assert whether the properties can be read and written to.
            foreach(var property in hhg_reflected.GetProperties())
            {
                Assert.IsTrue(property.CanRead);
                Assert.IsTrue(property.CanWrite);
            }
        }

        [TestMethod]
        public void HolyHandGrenadeHasCallableMethods()
        {
            var hhg = new HolyHandGrenade();

            // Gets the method via reflection and invokes it on the object constructed earlier.
            var getVerseMethod = typeof(HolyHandGrenade).GetMethod("GetVerseFromBible", BindingFlags.Public | BindingFlags.Instance);
            var output = getVerseMethod.Invoke(hhg, null);

            Assert.AreEqual(hhg.GetVerseFromBible(), output);
        }
    }
}
