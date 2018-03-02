using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LiveSiteRace
{
    public class SiteDownloader
    {
        private static int SitePlace;

        /// <summary>
        /// Creates an array of URLs to download and passes them to AsyncDownload.
        /// </summary>
        /// <param name="args">A generic argument array.</param>
        static void Main(string[] args)
        {
            string[] urls = new string[]
            {
                "http://www.theuselessweb.com",
                "https://www.youtube.com/watch?v=BVQSr8NpjrU",
                "https://www.google.com",
                "https://msdn.microsoft.com/en-us/library/system.diagnostics.stopwatch(v=vs.110).aspx",
                "https://en.wikipedia.org/wiki/Evolve_(Imagine_Dragons_album)"
            };
            AsyncDownload(urls);
            SitePlace = 0;
            Console.ReadKey();
        }
        /// <summary>
        /// Downloads a list of sites asynchronously and ranks them.
        /// </summary>
        /// <param name="urlList">The URLs of the sites you want to download.</param>
        /// <returns>A list of LoadedWebsite instances.</returns>
        public static List<LoadedWebsite> AsyncDownload(string[] urlList)
        {
            var loadedSites = new List<LoadedWebsite>();

            var tasks = new List<Task>();

            foreach (var url in urlList)
            {
                tasks.Add(GetAsync(url)
                    .ContinueWith(t => loadedSites.Add(t.Result)));
            }

            Task.WaitAll(tasks.ToArray());

            foreach (var site in loadedSites)
            {
                Console.WriteLine($"In place {site.LoadPosition}, {site.Url} loaded {site.UrlContents.Length} characters of information in {site.LoadTime}ms.");
                Console.WriteLine($"This site downloaded at a speed of {site.UrlContents.Length / site.LoadTime} characters per ms.");
            }

            return loadedSites;
        }

        /// <summary>
        /// Downloads a site and records stats about it.
        /// </summary>
        /// <param name="url">The URL of the site to be downloaded.</param>
        /// <returns>The loaded website in an instance of LoadedWebsite.</returns>
        private static async Task<LoadedWebsite> GetAsync(string url)
        {
            // Create an object to use in a lock.
            var thisLock = new Object();

            // Create a new timer object.
            var loadTimer = new Stopwatch();

            // Add a reference to System.Net.Http to declare client.
            var client = new HttpClient();

            Console.WriteLine($"{url}: starting download...");

            // GetStringAsync returns a Task<string>.
            var getStringTask = client.GetStringAsync(url);

            // Begins the timer.
            loadTimer.Start();

            // The await operator suspends AccessTheWebAsync.
            string urlContents = await getStringTask;

            // Stops the timer.
            loadTimer.Stop();

            Console.WriteLine($"{url}: download complete.");

            // Locks the SitePlace propery and returns in order to ensure that it is not incremented twice before the LoadedWebsite is returned.
            lock (thisLock)
            {
                SitePlace++;
                return new LoadedWebsite(url, urlContents, loadTimer.ElapsedMilliseconds, SitePlace);
            }
        }
    }
}
