using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionExercise;

namespace ReflctionTests
{
    [TestClass]
    public class LaptopTests
    {
        [TestMethod]
        public void CanReflectLaptop()
        {
            float laptopRatio = 16 / 9;
            float newLaptopRatio = 18 / 9;
            bool laptopScreenOn = true;
            bool newLaptopScreenOn = false;

            var laptop = Activator.CreateInstance(typeof(Laptop), laptopRatio, laptopScreenOn) as Laptop;
            var laptopProperties = laptop.GetType().GetProperties();
            var powerButtonMethod = laptop.GetType().GetMethod("PressPowerButton");

            Assert.AreNotEqual(laptopProperties.Length, 0);

            typeof(Laptop).GetProperty("ScreenPixelRatio").SetValue(laptop, newLaptopRatio);
            typeof(Laptop).GetProperty("ScreenOn").SetValue(laptop, newLaptopScreenOn);

            foreach (var property in laptopProperties)
            {
                var value = property.GetValue(laptop);

                switch (property.Name)
                {
                    case "ScreenPixelRatio":
                        Assert.AreEqual(value, newLaptopRatio);
                        break;
                    case "ScreenOn":
                        Assert.AreEqual(value, newLaptopScreenOn);
                        Assert.AreEqual(powerButtonMethod.Invoke(laptop, null), !newLaptopScreenOn);
                        break;
                    default:
                        Assert.Fail();
                        break;
                }
            }
        }
    }
}
