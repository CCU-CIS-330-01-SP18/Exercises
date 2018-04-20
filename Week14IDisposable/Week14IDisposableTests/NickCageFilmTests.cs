using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14IDisposable;

namespace Week14IDisposableTests
{
    [TestClass]
    public class NickCageFilmTests
    {
        [TestMethod]
        public void NickCageFilmsDisposed()
        {
            var film = new NickCageFilm
            {
                Director = "Jon Turteltaub",
                FilmName = "National Treasure",
                FamousQuote = "When are we gonna get there? I'm hungry. This car smells weird."
            };

            Assert.IsNotNull(film.Director);
            Assert.IsNotNull(film.FilmName);
            Assert.IsNotNull(film.FamousQuote);

            film.Dispose();

            Assert.IsNull(film.Director);
            Assert.IsNull(film.FilmName);
            Assert.IsNull(film.FamousQuote);
        }
    }
}
