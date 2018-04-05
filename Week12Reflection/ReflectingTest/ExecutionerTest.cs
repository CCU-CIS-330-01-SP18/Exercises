using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectingTest
{
    [TestClass]
    public class ExecutionerTest
    {
        [TestMethod]
        public void CanConstructAndUsePropertiesAndMethodsForExecutioner()
        {
            // Confirm the class can be constructed.
            var type = Type.GetType("Reflecting.Executioner, Reflecting", true);
            var instance = Activator.CreateInstance(type);

            // Confirm that each property can be written and read.
            var primaryWeaponProperty = instance.GetType().GetProperty("PrimaryWeapon", BindingFlags.NonPublic | BindingFlags.Instance);
            primaryWeaponProperty.SetValue(instance, "Great Axe", null);
            var primaryWeaponValue = primaryWeaponProperty.GetValue(instance, null);

            var sidearmProperty = instance.GetType().GetProperty("PrimaryWeapon", BindingFlags.NonPublic | BindingFlags.Instance);
            sidearmProperty.SetValue(instance, "Hatchet", null);
            var sidearmPropertyValue = sidearmProperty.GetValue(instance, null);

            // Confirm that each method can be invoked.
            var decapitateMethod = instance.GetType().GetMethod("Decapitate", BindingFlags.NonPublic | BindingFlags.Instance);
            decapitateMethod.Invoke(instance, null);

            Assert.IsNotNull(instance);
            Assert.AreEqual(primaryWeaponValue, "Great Axe");
            Assert.AreEqual(sidearmPropertyValue, "Hatchet");
        }
    }
}
