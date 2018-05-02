using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsFarm
{
    /// <summary>
    /// Represents an instance of a sheep.
    /// </summary>
    public class Sheep : Animal
    {
        /// <summary>
        /// A constructor method that initializes most of the values for a sheep.
        /// </summary>
        /// <param name="name">The sheep's name.</param>
        public Sheep(string name) : base(name)
        {
            AgeMonths = 0;
            Strength = 1;
            AverageLifespan = 132;
            PoundsOfFoodPerMonth = 120;
            MinimumSlaughterAge = 10;
            BestSlaughterAge = AverageLifespan * 0.25f;
            Products = new Dictionary<Product.Produce, float> { { Product.Produce.Wool, 0.04f } };
            MeatType = Product.Produce.Lamb;
            FoodType = Product.Food.Hay;
        }
    }
}
