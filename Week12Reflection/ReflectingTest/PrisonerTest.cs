using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectingTest
{
    [TestClass]
    public class PrisonerTest
    {
        [TestMethod]
        public void CanConstructAndUsePropertiesAndMethodsForPrisoner()
        {
            // Confirm the class can be constructed.
            var type = Type.GetType("Reflecting.Prisoner, Reflecting", true);
            var instance = Activator.CreateInstance(type);

            // Confirm that each property can be written and read.
            var lastWordsProperty = instance.GetType().GetProperty("LastWords", BindingFlags.NonPublic | BindingFlags.Instance);
            lastWordsProperty.SetValue(instance, "Dylan, you're one morbid SOB!", null);
            var lastWordsValue = lastWordsProperty.GetValue(instance, null);

            var isCryingProperty = instance.GetType().GetProperty("IsCrying", BindingFlags.NonPublic | BindingFlags.Instance);
            isCryingProperty.SetValue(instance, true, null);
            var isCryingValue = isCryingProperty.GetValue(instance, null);

            // Confirm that each method can be invoked.
            var dieMethod = instance.GetType().GetMethod("Die", BindingFlags.NonPublic | BindingFlags.Instance);
            dieMethod.Invoke(instance, null);

            Assert.IsNotNull(instance);
            Assert.AreEqual(lastWordsValue, "Dylan, you're one morbid SOB!");
            Assert.AreEqual(isCryingValue, true);
        }
    }
}
