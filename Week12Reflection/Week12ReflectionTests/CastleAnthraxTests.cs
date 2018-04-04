using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12Reflection;

namespace Week12ReflectionTests
{
    [TestClass]
    public class CastleAnthraxTests
    {
        [TestMethod]
        public void CastleAnthraxCanBeConstructed()
        {
            // Reflected object.
            var ca_reflected = Activator.CreateInstance(typeof(CastleAnthrax)) as CastleAnthrax;

            // Standard object (for testing)
            var ca_standard = new CastleAnthrax();

            Assert.IsInstanceOfType(ca_reflected, typeof(CastleAnthrax));
            Assert.AreEqual(ca_reflected.GetNumberOfMembers(), ca_standard.GetNumberOfMembers());
        }

        [TestMethod]
        public void CastleAnthraxHasWorkingProperties()
        {
            // Reflected object.
            var ca_reflected = typeof(CastleAnthrax);
            
            // For each property, assert whether the properties can be read and written to.
            foreach(var property in ca_reflected.GetProperties())
            {
                Assert.IsTrue(property.CanRead);
                Assert.IsTrue(property.CanWrite);
            }
        }

        [TestMethod]
        public void CastleAnthraxHasCallableMethods()
        {
            var ca = new CastleAnthrax();

            // Gets the method via reflection and invokes it on the object constructed earlier.
            var getMembersMethod = typeof(CastleAnthrax).GetMethod("GetNumberOfMembers", BindingFlags.Public | BindingFlags.Instance);
            var output = getMembersMethod.Invoke(ca, null);

            Assert.AreEqual(ca.GetNumberOfMembers(), output);
        }
    }
}
