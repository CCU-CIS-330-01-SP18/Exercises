using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14IDisposableExercise;

namespace Week14IDisposableExerciseTests
{
    [TestClass]
    public class InfinityWarTests
    {
        [TestMethod]
        public void InfinityWarDisposes()
        {
            var movie = new InfinityWar();
            string summary = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe. ";
            string date = "Apr 27, 2018";
            movie.Summary = summary;
            movie.DateReleased = date;

            movie.Dispose();
            Assert.IsNull(movie.Summary);
            Assert.IsNull(movie.DateReleased);
        }
    }
}
