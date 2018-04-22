using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14IDisposableExercise;

namespace Week14IDisposableExerciseTests
{
    [TestClass]
    public class AvengersTests
    {
        [TestMethod]
        public void AvengersDisposes()
        {
            var movie = new Avengers();
            string powers = "Being a god, super serum, money, gamma radiation...you know the rest...";
            string name = "Thor, Captain America, Iron Man, Hulk...you know the rest...";
            movie.SuperPowers = powers;
            movie.Name = name;
            
            movie.Dispose();
            Assert.IsNull(movie.SuperPowers);
            Assert.IsNull(movie.Name);
        }
    }
}
