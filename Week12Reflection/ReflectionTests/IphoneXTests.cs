using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12Reflection;

namespace ReflectionTests
{
    [TestClass]
    public class Week12RelectionTests
    {
        [TestMethod]
        public void IphoneXConstructionTest()
        {
            //Object created through standard instantiation. 
            var iPhoneX = new IphoneX();

            //Object created using reflection.
            var reflectionIphoneX = Activator.CreateInstance(typeof(IphoneX)) as IphoneX;

            Assert.IsNotNull(iPhoneX);
            Assert.IsNotNull(reflectionIphoneX);
            Assert.IsInstanceOfType(reflectionIphoneX, typeof(IphoneX));
        }

        [TestMethod]
        public void IphoneXPropertyTest()
        {
            //Object created through standard instantiation. 
            var iPhoneX = new IphoneX();

            //Object created using reflection.
            var reflectionIphoneX = Activator.CreateInstance(typeof(IphoneX)) as IphoneX;

            //Set both properties to false and verify.
            reflectionIphoneX.GetType().GetProperty("IsOverpriced").SetValue(reflectionIphoneX, false);
            reflectionIphoneX.GetType().GetProperty("IsAllowedThroughTSA").SetValue(reflectionIphoneX, false);
            Assert.AreEqual(false, reflectionIphoneX.GetType().GetProperty("IsOverpriced").GetValue(reflectionIphoneX, null));
            Assert.AreEqual(false, reflectionIphoneX.GetType().GetProperty("IsAllowedThroughTSA").GetValue(reflectionIphoneX, null));

            //Set both propertiesto true and verify.
            reflectionIphoneX.GetType().GetProperty("IsOverpriced").SetValue(reflectionIphoneX, true);
            reflectionIphoneX.GetType().GetProperty("IsAllowedThroughTSA").SetValue(reflectionIphoneX, true);
            Assert.AreEqual(true , reflectionIphoneX.GetType().GetProperty("IsOverpriced").GetValue(reflectionIphoneX, null));
            Assert.AreEqual(true, reflectionIphoneX.GetType().GetProperty("IsAllowedThroughTSA").GetValue(reflectionIphoneX, null));

            Assert.IsTrue(reflectionIphoneX.GetType().GetProperty("IsOverpriced").CanRead);
            Assert.IsTrue(reflectionIphoneX.GetType().GetProperty("IsOverpriced").CanWrite);

            Assert.IsTrue(reflectionIphoneX.GetType().GetProperty("IsAllowedThroughTSA").CanRead);
            Assert.IsTrue(reflectionIphoneX.GetType().GetProperty("IsAllowedThroughTSA").CanWrite);
        }

        [TestMethod]
        public void IphoneXMethodTest()
        {
            //Object created using reflection.
            var reflectionIphoneX = Activator.CreateInstance(typeof(IphoneX)) as IphoneX;

            //Because the "EmptyBankAccount" method only really writes to the console, I added another step to have it change the object's "IsOverpriced"
            //  property to true. The code below sets the reflectionIphoneX's "IsOverpriced" property to false, so that I may check to see if it 
            //  is true after the method is run, confirming that the method ran.
            reflectionIphoneX.GetType().GetProperty("IsOverpriced").SetValue(reflectionIphoneX, false);

            var iPhoneXMethod = reflectionIphoneX.GetType().GetMethod("EmptyBankAccount");
            iPhoneXMethod.Invoke(reflectionIphoneX, null);

            //Checks to see if the "IsOverpriced" changed to true.
            Assert.AreEqual(true, reflectionIphoneX.GetType().GetProperty("IsOverpriced").GetValue(reflectionIphoneX, null));
        }
    }
}
