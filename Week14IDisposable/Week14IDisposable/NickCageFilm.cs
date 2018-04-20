namespace Week14IDisposable
{
    /// <summary>
    /// A Nicolas Cage film; these movies require their own object.
    /// </summary>
    public class NickCageFilm : ActionFilm
    {
        /// <summary>
        /// Another field of glory, a boolean flag for disposal.
        /// </summary>
        bool disposed = false;

        /// <summary>
        /// Nicolas Cage's catchphrase for this film.
        /// </summary>
        public string FamousQuote { get; set; }

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
                FamousQuote = null;
            }

            disposed = true;
            base.Dispose(disposing);
        }
    }
}
