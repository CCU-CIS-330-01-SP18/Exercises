using ProductList.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;

namespace ProductList.Controllers
{
    public class ProductsController : ApiController
    {
        private const string FILENAME = "products.json";
        private GenericStorage Storage;

        private const int OverallMarketQuantity = 100000;

        public enum MarketProductAttributes { MarketPrice, MarketQuantity }
        public enum Produce { Hay, Grain, Eggs, Milk, Butter, Wool, Bacon, Beef, Lamb, Chicken }

        private Tuple<Produce, float, int>[] ProducePricesQuantity = new Tuple<Produce, float, int>[]
        {
            Tuple.Create(Produce.Hay, 0.30f, 330000),
            Tuple.Create(Produce.Grain, 0.16f, 625000),
            Tuple.Create(Produce.Eggs, 1.2f, 83000),
            Tuple.Create(Produce.Chicken, 6f, 16600),
            Tuple.Create(Produce.Milk, 0.36f, 277000),
            Tuple.Create(Produce.Butter, 3f, 33000),
            Tuple.Create(Produce.Beef, 19f, 5260),
            Tuple.Create(Produce.Wool, 1.45f, 71400),
            Tuple.Create(Produce.Lamb, 22f, 4540),
            Tuple.Create(Produce.Bacon, 21f, 4760)
        };

        public ProductsController()
        {
            Storage = new GenericStorage();
        }

        private List<Product> CreateProducts()
        {
            var products = new List<Product>();
            foreach (var product in ProducePricesQuantity)
            {
                products.Add(new Product { Name = Convert.ToString(product.Item1), MarketPrice = product.Item2, MarketQuantity = product.Item3 });
            }

            return products;
        }

        private async Task<T> GetProducts<T>()
        {
            var products = await Storage.Get<T>(FILENAME);

            if (products == null)
            {
                var newProducts = CreateProducts();

                await Storage.Save(newProducts, FILENAME);

                return await Storage.Get<T>(FILENAME);
            }
            else
            {
                return products;
            }
        }

        private async Task ChangeProductAttribute(string productName, MarketProductAttributes attribute, float change)
        {
            var products = await GetProducts<JArray>();
            string attributeName = Convert.ToString(attribute);
            var currentValue = products.Where(x => x["Name"].Value<string>() == productName).FirstOrDefault();

            currentValue[attributeName] = (float)currentValue[attributeName] + change;
            await Storage.Save(products.ToObject<IEnumerable<Product>>(), FILENAME);
        }

        /// <summary>
        /// Gets the list of products.
        /// </summary>
        /// <returns>The prooducts.</returns>
        [HttpGet]
        [Route("~/products")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await GetProducts<List<Product>>();
        }

        /// <summary>
        /// Gets a specific product.
        /// </summary>
        /// <param name="name">Identifier for the product.</param>
        /// <returns>The requested product.</returns>
        [HttpGet]
        [Route("~/products/{name}")]
        public async Task<Product> Get([FromUri] string name)
        {
            var products = await GetProducts<IEnumerable<Product>>();
            return products.FirstOrDefault(x => x.Name == name);
        }

        [HttpGet]
        [Route("~/products/{name}/buy/{amountToBuy}")]
        public async Task<Product> Buy([FromUri] string name, [FromUri] float amountToBuy)
        {
            ChangeProductAttribute(name, MarketProductAttributes.MarketQuantity, -amountToBuy).Wait();
            return await Get(name);
        }

        [HttpGet]
        [Route("~/products/{name}/sell/{amountToSell}")]
        public async Task<Product> Sell([FromUri] string name, [FromUri] float amountToSell)
        {
            ChangeProductAttribute(name, MarketProductAttributes.MarketQuantity, amountToSell).Wait();
            return await Get(name);
        }

        [HttpGet]
        [Route("~/products/MoveMarket")]
        public async Task<IEnumerable<Product>> MoveMarket()
        {
            var random = new Random();
            var products = await GetProducts<List<Product>>();

            foreach (var product in products)
            {
                var productInfo = ProducePricesQuantity.Where(x => x.Item1 == (Produce)Enum.Parse(typeof(Produce), product.Name)).FirstOrDefault();

                float quantityPercentage = product.MarketQuantity / productInfo.Item3;
                float priceDifference = product.MarketPrice - productInfo.Item2;
                int quantityOfTraders = (int)((Math.Abs(product.MarketQuantity - productInfo.Item3) + (productInfo.Item3 * 0.001)) * 0.3f);
                float buyers = (float)(priceDifference < 0 ? 0.5 + (random.NextDouble() * 0.5) - (random.NextDouble() * 0.2) : (random.NextDouble() * 0.2f)) * quantityOfTraders;
                float sellers = quantityOfTraders - buyers;
                float newPriceDifference = (float)(((2 - quantityPercentage) * productInfo.Item2 * (1 + random.NextDouble() * 0.01f - random.NextDouble() * 0.01f)) - product.MarketPrice);

                await ChangeProductAttribute(product.Name, MarketProductAttributes.MarketQuantity, (sellers - buyers));
                await ChangeProductAttribute(product.Name, MarketProductAttributes.MarketPrice, newPriceDifference);
            }

            return await GetProducts<List<Product>>();
        }

        [HttpGet]
        [Route("~/products/ResetMarket")]
        public async Task<IEnumerable<Product>> ResetMarket()
        {
            Storage.Delete(FILENAME).Wait();
            return await GetProducts<List<Product>>();
        }
    }
}