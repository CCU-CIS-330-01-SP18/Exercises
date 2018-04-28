using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Threading;

namespace WeatherApp
{
    /// <summary>
    /// A class retrieves weather data from an API and presents the data in a human readable format in an asynchronous manner. 
    /// </summary>
    public class GetWeather
    {
        /// <summary>
        /// Asynchronously calls a weather API and reetrieves Json data.
        /// </summary>
        /// <returns>a RootObject object containing the resulting weather data.</returns>
       public static async Task<RootObject> APIcall(string city)
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=19021c4a1c8b014b72530857333b2019&mode");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "df4c4f90-a3b3-48a4-8de5-5b12ce307198");
            request.AddHeader("cache-control", "no-cache");
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse response  = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

            return JsonConvert.DeserializeObject<RootObject>(response.Content);
        }

        public static string GetCity()
        {
            Console.WriteLine("\r\nEnter the name of your city:");
            var city = Console.ReadLine();
            return city;
        }
    }
}
