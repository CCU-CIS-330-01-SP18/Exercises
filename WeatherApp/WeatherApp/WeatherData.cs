using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// A class that represents cooridnate data from JSON response.
    /// </summary>
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    /// <summary>
    /// A class that represents weather data from JSON response.
    /// </summary>
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    /// <summary>
    /// A class that represents the main data from JSON response.
    /// </summary>
    public class Main
    {
        public double temp { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    /// <summary>
    /// A class that represents wind data from JSON response.
    /// </summary>
    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    /// <summary>
    /// A class that represents cloud data from JSON response.
    /// </summary>
    public class Clouds
    {
        public int all { get; set; }
    }

    /// <summary>
    /// A class that represents system data from JSON response.
    /// </summary>
    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    /// <summary>
    /// A class that represents the Json response from the API call. 
    /// </summary>
    public class RootObject
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

        /// <summary>
        /// Generates weather report from Json response.
        /// </summary>
        public bool GenerateReport()
        {
            try
            {
                Console.WriteLine("**********Your Weather Report**********");
                Console.WriteLine("In " + name + ":");
                Console.WriteLine("    Weather: " + weather[0].description);
                Console.WriteLine("    Current Temperature: " + ((9 / 5) * (main.temp - 273) + 32) + " Degrees Fahrenheit.");
                Console.WriteLine("    Humidity: " + main.humidity + "%");
                Console.WriteLine("    Wind Speed: " + wind.speed + " Miles per Hour.");
                Console.WriteLine("\r\n----Clothing Suggestions----");
                GetSuggestions();
                return true;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Failed to retrieve weater data: Check city name spelling. \r\n" + e);
                Console.WriteLine("Press ENTER to retry.");
                return false;
            }
            
        }

        /// <summary>
        /// Selects clothing suggestions to add to the weather report, depending on weather conditions. 
        /// </summary>
        public void GetSuggestions()
        {
            if (((9 / 5) * (main.temp - 273) + 32) <= 45)
            {
                Console.WriteLine("Looks Like its pretty chilly! Grab a jacket!");
            }
            else if (((9 / 5) * (main.temp - 273) + 32) > 45 && ((9 / 5) * (main.temp - 273) + 32) <= 70)
            {
                Console.WriteLine("Balmy weather today, Go for the T-shirt");
            }
            else
            {
                Console.WriteLine("Its going to be hot! Shorts are advised.");
            }

            if (wind.speed >= 15 && wind.speed <= 25)
            {
                Console.WriteLine("Its breezy out there, maybe a pull over?");
            }
            else if (wind.speed < 15)
            {
                Console.WriteLine("The wind is still today!");
            }
            else
            {
                Console.WriteLine("Hold onto your hat! Its a windy day! Grab a wind breaker.");
            }

            Console.WriteLine("\r\nThats all from me! See ya next time!");
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
    }
}
