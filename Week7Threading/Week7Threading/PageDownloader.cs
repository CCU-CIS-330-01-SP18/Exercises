using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Week7Threading
{
    /// <summary>
    /// Downloads a list of webpages asynchronously, and calculate which download the fastest.
    /// </summary>
    class PageDownloader
    {
        /// <summary>
        /// The entry point for the program.
        /// </summary>
        /// <param name="args">Launch arguments (not used).</param>
        static void Main(string[] args)
        {
            Console.WriteLine("== Welcome to Downloadifier! ==");
            HandleDownloads();
            Console.WriteLine("== Thanks for using Downloadifier! ==");
        }

        /// <summary>
        /// Begins the process of downloading a list of websites, and calculates which downloaded fastest and slowest.
        /// </summary>
        private static void HandleDownloads()
        {
            string[] urls = new string[]
            {
                "http://apple.com",
                "http://hadenw.tech",
                "http://downloadmorewam.com",
                "http://whyamialoser.com",
                "http://ccu.edu",
                "http://amazon.com",
                "http://github.com",
                "http://crunchyroll.com"
            };

            List<Task> tasks = new List<Task>();
            Dictionary<string, long> pages = new Dictionary<string, long>();

            foreach (string url in urls)
            {
                tasks.Add(DownloadWebpage(url)
                    .ContinueWith(t => pages.Add(url, t.Result)));
            }

            // Wait for all tasks to complete.
            Task.WaitAll(tasks.ToArray());

            // Determine which websites were fastest / slowest.
            long slowestTime = pages.Values.Max();
            long fastestTime = pages.Values.Min();
            string slowestURL = pages.FirstOrDefault(x => x.Value == slowestTime).Key;
            string fastestURL = pages.FirstOrDefault(x => x.Value == fastestTime).Key;

            // Print the data to the console.
            Console.WriteLine($"[LOSER] \"{slowestURL}\" took the longest with {slowestTime}ms");
            Console.WriteLine($"[WINNER] \"{fastestURL}\" was the fastest with {fastestTime}ms");
        }

        /// <summary>
        /// Performs the work of downloading a webpage and measuring the time elapsed.
        /// </summary>
        /// <param name="url">The URL you wish to download.</param>
        /// <returns>The number of milliseconds elapsed during the download.</returns>
        private static async Task<long> DownloadWebpage(string url)
        {
            Console.WriteLine($"Downloading \"{url}\"...");
            Stopwatch sw = new Stopwatch();
            HttpClient downloadClient = new HttpClient();
            sw.Start();
            string downloadContents = await downloadClient.GetStringAsync(url);
            sw.Stop();
            Console.WriteLine($"\"{url}\" was downloaded in {sw.ElapsedMilliseconds}ms!");

            return sw.ElapsedMilliseconds;
        }
    }
}
