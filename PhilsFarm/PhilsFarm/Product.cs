using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsFarm
{
    /// <summary>
    /// Represents an instane of a product.
    /// </summary>
    public class Product
    {
        public enum Food { Hay, Grain }
        public enum Produce { Eggs, Milk, Butter, Wool, Bacon, Beef, Lamb, Chicken }

        public string Name { get; set; }
        public float MarketPrice { get; set; }
        public float MarketQuantity { get; set; }

        /// <summary>
        /// A constructor for food products.
        /// </summary>
        /// <param name="foodName">The name of the food to give the product.</param>
        public Product(Food foodName)
        {
            Name = foodName.ToString();
        }

        /// <summary>
        /// A constructor for produce products.
        /// </summary>
        /// <param name="produceName">The name of the produce to give the product.</param>
        public Product(Produce produceName)
        {
            Name = produceName.ToString();
        }

        /// <summary>
        /// A constructor for when it is not neccesary to give a product a name.
        /// </summary>
        private Product() { }
    }
}
