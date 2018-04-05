using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12Reflection;
using System.Reflection;

namespace ReflectionTests
{
    [TestClass]
    public class SpaceshipTests
    {
        [TestMethod]
        public void ReflectSpaceship()
        {
            var spaceShip = Activator.CreateInstance(typeof(Spaceship), 5.0f, true) as Spaceship;
            var spaceShip2 = new Spaceship(5.0f, true);

            Assert.IsInstanceOfType(spaceShip, typeof(Spaceship));
            Assert.AreEqual(spaceShip.EnginePower, spaceShip2.EnginePower);
            Assert.AreEqual(spaceShip.Launched, spaceShip2.Launched);
        }
    }
}
