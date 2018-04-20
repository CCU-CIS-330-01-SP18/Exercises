using System;

namespace Week14IDisposable
{
    /// <summary>
    /// Represents a Marvel action film.
    /// </summary>
    public class MarvelFilm : ActionFilm
    {
        /// <summary>
        /// Boolean flag for disposal as per the rules on MSDN.
        /// </summary>
        bool disposed = false;

        /// <summary>
        /// A short summary of the movie's plot.
        /// </summary>
        public string Plot { get; set; }

        /// <summary>
        /// Disposes managed resources.
        /// </summary>
        /// <param name="disposing">Whether we are disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                Plot = null;
            }

            disposed = true;
            base.Dispose(disposing);
        }
    }
}
