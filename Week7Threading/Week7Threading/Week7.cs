using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Week7Threading
{
    /// <summary>
    /// Week 7 Threading. Async checking the download size of websites.
    /// I am sorry this program is super boring and super basic, I did not manage my time
    /// and started rather late. SORRY!
    /// </summary>
    public class Week7
    {
        static void Main(string[] args)
        {
            WebsiteDownload();

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        /// <summary>
        /// Loops through an array and checks the download size.
        /// </summary>
        public static void WebsiteDownload()
        {
            string[] urls = new string[]
            {
                "http://msdn.microsoft.com",
                "http://www.yahoo.com",
            };

            List<Task> tasks = new List<Task>();

            foreach (var url in urls)
            {
                tasks.Add(GetAsync(url).ContinueWith(t => Console.WriteLine($"{url}: page size: {t.Result:n0}.")));
            }

            Task.WaitAll(tasks.ToArray());
        }


        /// <summary>
        /// Checks the size of the download.
        /// </summary>
        /// <param name="url">The website url you want to use.</param>
        /// <returns>The length of the website download</returns>
        public static async Task<int> GetAsync(string url)
        {
            HttpClient client = new HttpClient();

            Console.WriteLine($"{url}: starting download...");

            Task<string> getStringTask = client.GetStringAsync(url);

            // You can do work here that doesn't rely on the string from GetStringAsync.
            Console.WriteLine($"{url}: doing some other work here...");

            string urlContents = await getStringTask;

            Console.WriteLine($"{url}: download complete.");

            // The return statement specifies an integer result.
            return urlContents.Length;
        }

    }
}
