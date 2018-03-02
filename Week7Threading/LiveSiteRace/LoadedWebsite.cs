namespace LiveSiteRace
{
    /// <summary>
    /// Contains information about a website that has been loaded.
    /// </summary>
    public class LoadedWebsite
    {
        public readonly string Url, UrlContents;
        public readonly long LoadTime;
        public readonly int LoadPosition;

        /// <summary>
        /// The LoadedWebsite constructor.
        /// </summary>
        /// <param name="url">The URL of the loaded website.</param>
        /// <param name="urlContents">The contents of the loaded website.</param>
        /// <param name="loadTime">How long in ms it took to load the website.</param>
        /// <param name="loadPosition">How the website placed in relation to other loaded websites.</param>
        public LoadedWebsite(string url, string urlContents, long loadTime, int loadPosition)
        {
            Url = url;
            UrlContents = urlContents;
            LoadTime = loadTime;
            LoadPosition = loadPosition;
        }
    }
}
