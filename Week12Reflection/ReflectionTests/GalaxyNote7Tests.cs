using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12Reflection;

namespace ReflectionTests
{
    [TestClass]
    public class GalaxyNote7Tests
    {
        [TestMethod]
        public void GalaxyNote7ConstructionTest()
        {
            //Object created through standard instantiation. 
            var galaxyNote7 = new GalaxyNote7();

            //Object created using reflection.
            var reflectionGalaxyNote7 = Activator.CreateInstance(typeof(GalaxyNote7)) as GalaxyNote7;

            Assert.IsNotNull(galaxyNote7);
            Assert.IsNotNull(reflectionGalaxyNote7);
            Assert.IsInstanceOfType(reflectionGalaxyNote7, typeof(GalaxyNote7));
        }

        [TestMethod]
        public void GalaxyNote7PropertyTest()
        {
            //Object created through standard instantiation. 
            var galaxyNote7 = new GalaxyNote7();

            //Object created using reflection.
            var reflectionGalaxyNote7 = Activator.CreateInstance(typeof(GalaxyNote7)) as GalaxyNote7;

            //Set both properties to false and verify.
            reflectionGalaxyNote7.GetType().GetProperty("IsOverpriced").SetValue(reflectionGalaxyNote7, true);
            reflectionGalaxyNote7.GetType().GetProperty("IsAllowedThroughTSA").SetValue(reflectionGalaxyNote7, true);
            Assert.AreEqual(true, reflectionGalaxyNote7.GetType().GetProperty("IsOverpriced").GetValue(reflectionGalaxyNote7, null));
            Assert.AreEqual(true, reflectionGalaxyNote7.GetType().GetProperty("IsAllowedThroughTSA").GetValue(reflectionGalaxyNote7, null));

            //Set both propertiesto true and verify.
            reflectionGalaxyNote7.GetType().GetProperty("IsOverpriced").SetValue(reflectionGalaxyNote7, false);
            reflectionGalaxyNote7.GetType().GetProperty("IsAllowedThroughTSA").SetValue(reflectionGalaxyNote7, false);
            Assert.AreEqual(false, reflectionGalaxyNote7.GetType().GetProperty("IsOverpriced").GetValue(reflectionGalaxyNote7, null));
            Assert.AreEqual(false, reflectionGalaxyNote7.GetType().GetProperty("IsAllowedThroughTSA").GetValue(reflectionGalaxyNote7, null));

            Assert.IsTrue(reflectionGalaxyNote7.GetType().GetProperty("IsOverpriced").CanRead);
            Assert.IsTrue(reflectionGalaxyNote7.GetType().GetProperty("IsOverpriced").CanWrite);

            Assert.IsTrue(reflectionGalaxyNote7.GetType().GetProperty("IsAllowedThroughTSA").CanRead);
            Assert.IsTrue(reflectionGalaxyNote7.GetType().GetProperty("IsAllowedThroughTSA").CanWrite);
        }

        [TestMethod]
        public void GalaxyNte7MethodTest()
        {
            //Object created using reflection.
            var reflectionGalaxyNote7 = Activator.CreateInstance(typeof(GalaxyNote7)) as GalaxyNote7;

            //Because the "Detonate" method only really writes to the console, I added another step to have it change the object's "IsAllowedTroughTSA"
            //  property to false. The code directly below sets the reflectionGalaxyNote7's "IsAllowedTroughTSA" property to true, so that I may check to see if it 
            //  is false after the method is run, confirming that the method ran.
            reflectionGalaxyNote7.GetType().GetProperty("IsAllowedThroughTSA").SetValue(reflectionGalaxyNote7, true);

            var iPhoneXMethod = reflectionGalaxyNote7.GetType().GetMethod("Detonate");
            iPhoneXMethod.Invoke(reflectionGalaxyNote7, null);

            //Checks to see if the "IsAllowedTroughTSA" has changed to false.
            Assert.AreEqual(false, reflectionGalaxyNote7.GetType().GetProperty("IsAllowedThroughTSA").GetValue(reflectionGalaxyNote7, null));
        }
    }
}
