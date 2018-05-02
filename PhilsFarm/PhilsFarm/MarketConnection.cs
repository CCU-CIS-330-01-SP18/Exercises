using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace PhilsFarm
{
    /// <summary>
    /// Represents a connection to the market API.
    /// </summary>
    public class MarketConnection
    {
        private const string ApiUrl = @"https://farmmarket.azurewebsites.net/products";

        /// <summary>
        /// Gets a product instance from the market by name.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <returns>The product instance.</returns>
        public async Task<Product> GetProducts(string name)
        {
            var unparsedJson = await RequestData($"{ApiUrl}/{name}");

            return JsonConvert.DeserializeObject<Product>(unparsedJson);
        }

        /// <summary>
        /// Gets all product instances from the market.
        /// </summary>
        /// <returns>All market product instances.</returns>
        public async Task<Product[]> GetProducts()
        {
            var unparsedJson = await RequestData($"{ApiUrl}");

            return JsonConvert.DeserializeObject<Product[]>(unparsedJson);
        }

        /// <summary>
        /// Changes the market quantity to reflect the amount of a product that the user purchased from it.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="amount">The amount of the product.</param>
        /// <returns>The task for this method.</returns>
        public async Task BuyProduct(string name, float amount)
        {
            await new HttpClient().GetAsync($"{ApiUrl}/{name}/buy/{amount}/");
        }

        /// <summary>
        /// Changes the market quantity to reflect the amount of a product that the user sold to it.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="amount">The amount of the product.</param>
        /// <returns>The task for this method.</returns>
        public async Task SellProduct(string name, float amount)
        {
            await new HttpClient().GetAsync($"{ApiUrl}/{name}/sell/{amount}/");
        }

        /// <summary>
        /// Changes the market prices and quantities based on its prices.
        /// </summary>
        /// <returns>The task for this method.</returns>
        public async Task MoveMarket()
        {
            await new HttpClient().GetAsync($"{ApiUrl}/MoveMarket");
            foreach (char character in "You can sense the market shifting...")
            {
                Console.Write(character);
                await Task.Delay(10);
            }
            await Task.Delay(500);
            Console.WriteLine("");
        }

        /// <summary>
        /// Resets the market to its default values.
        /// </summary>
        /// <returns>The task for this method.</returns>
        public async Task ResetMarket()
        {
            await new HttpClient().GetAsync($"{ApiUrl}/ResetMarket");
        }

        /// <summary>
        /// A helper method for retrieving data from a URI.
        /// </summary>
        /// <param name="uri">The URI to retrieve data from.</param>
        /// <returns>The data in string format.</returns>
        private async Task<string> RequestData(string uri)
        {
            return await new HttpClient().GetStringAsync(new Uri(uri));
        }
    }
}
