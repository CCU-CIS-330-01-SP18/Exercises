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
    public class PageDownloader
    {
        /// <summary>
        /// The entry point for the program. Public method for testing purposes.
        /// </summary>
        /// <param name="args">Launch arguments (not used).</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("== Welcome to Downloadifier! ==");
            HandleDownloads();
            Console.WriteLine("== Thanks for using Downloadifier! ==");
        }

        /// <summary>
        /// Begins the process of downloading a list of websites, and calculates which downloaded fastest and slowest. Public method for testing purposes.
        /// </summary>
        public static void HandleDownloads()
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
                "http://crunchyroll.com",
                "thisisafakeurl"
            };

            List<Task> tasks = new List<Task>();
            Dictionary<string, long> pages = new Dictionary<string, long>();

            foreach (string url in urls)
            {
                tasks.Add(DownloadWebpage(url)
                    .ContinueWith(t => addToDictionary(pages, url, t.Result)));
            }

            // Wait for all tasks to complete.
            Task.WaitAll(tasks.ToArray());

            // Remove any URLs that are <0ms

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
        /// Performs the work of downloading a webpage and measuring the time elapsed. Public method for testing purposes.
        /// </summary>
        /// <param name="url">The URL you wish to download.</param>
        /// <returns>The number of milliseconds elapsed during the download.</returns>
        public static async Task<long> DownloadWebpage(string url)
        {
            try
            {
                Console.WriteLine($"Downloading \"{url}\"...");
                Stopwatch sw = new Stopwatch();
                HttpClient downloadClient = new HttpClient();
                sw.Start();
                string downloadContents = await downloadClient.GetStringAsync(url);
                sw.Stop();
                Console.WriteLine($"\"{url}\" was downloaded in {sw.ElapsedMilliseconds}ms!");

                return sw.ElapsedMilliseconds;
            }catch(Exception e)
            {
                Console.WriteLine($"There was an error downloading the URL \"{url}\". The program has skipped this URL. Reason: {e.GetType()}");

                // Return a value less than 0 to indicate that there was a problem.
                return -1;
            }
        }

        public static void addToDictionary(Dictionary<string, long> d, string url, long result)
        {
            if(result > 0)
            {
                d.Add(url, result);
            }
        }
    }
}
