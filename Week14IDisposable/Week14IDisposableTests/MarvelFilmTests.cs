using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14IDisposable;

namespace Week14IDisposableTests
{
    [TestClass]
    public class MarvelFilmTests
    {
        [TestMethod]
        public void MarvelFilmIsDisposed()
        {
            var film = new MarvelFilm
            {
                Director = "Joss Whedon",
                FilmName = "Marvel's The Avengers",
                Plot = "A team of superheroes fight evil from outer space"
            };

            Assert.IsNotNull(film.Director);
            Assert.IsNotNull(film.FilmName);
            Assert.IsNotNull(film.Plot);

            film.Dispose();

            Assert.IsNull(film.Director);
            Assert.IsNull(film.FilmName);
            Assert.IsNull(film.Plot);
        }
    }
}
