using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12Reflection;
using System.Reflection;

namespace ReflectionTests
{
    [TestClass]
    public class AstronautTests
    {
        [TestMethod]
        public void ReflectAstronaut()
        {
            var astronaut = Activator.CreateInstance(typeof(Astronaut), 22, "Apollo 11") as Astronaut;
            var astronaut1 = new Astronaut(22, "Apollo 11");

            Assert.IsInstanceOfType(astronaut, typeof(Astronaut));
            Assert.AreEqual(astronaut.Age, astronaut1.Age);
            Assert.AreEqual(astronaut.Mission, astronaut1.Mission);
        }
    }
}
