using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14IDisposable;

namespace Week14IDisposableTests
{
    [TestClass]
    public class ActionFilmTests
    {
        [TestMethod]
        public void ActionFilmIsDisposed()
        {
            var film = new ActionFilm
            {
                Director = "Tommy Wiseau",
                FilmName = "The Room"
            };

            Assert.IsNotNull(film.Director);
            Assert.IsNotNull(film.FilmName);

            film.Dispose();

            Assert.IsNull(film.Director);
            Assert.IsNull(film.FilmName);
        }
    }
}
