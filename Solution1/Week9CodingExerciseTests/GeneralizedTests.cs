using System;
using Week9CodingExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week9CodingExerciseTests
{
    [TestClass]
    public class GeneralizedTests
    {
        [TestMethod]
        public void GeneralTests()
        {
            var batman = new Hero("Batman");
            var joker = new Villan("The Joker");
            var alfred = new ActionCharacter("Alfred Pennyworth");

            Assert.IsNotNull(batman);
            Assert.IsNotNull(joker);
            Assert.IsNotNull(alfred);

            Assert.IsInstanceOfType(batman, typeof(ActionCharacter));
            Assert.IsInstanceOfType(joker, typeof(ActionCharacter));
        }
    }
}
