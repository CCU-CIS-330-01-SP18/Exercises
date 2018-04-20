using System;
using System.Collections.Generic;

namespace Week14IDisposable
{
    /// <summary>
    /// Represents an action movie's metadata for a fictional review website.
    /// </summary>
    public class ActionFilm : IDisposable
    {
        /// <summary>
        /// This is a field so I don't have to XML comment it, but I will anyway because somebody is bound to dock points. Boolean flag for disposal.
        /// </summary>
        bool disposed = false;

        /// <summary>
        /// The director of a movie.
        /// </summary>
        public string Director { get; set; }

        /// <summary>
        /// The name of the action film.
        /// </summary>
        public string FilmName { get; set; }

        /// <summary>
        /// A generalized method that begins garbage collection as according to directions on MSDN.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all managed resources.
        /// </summary>
        /// <param name="disposing">Whether or not we are disposing this object.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                FilmName = null;
                Director = null;
            }

            disposed = true;
        }
    }
}
