using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsFarm
{
    /// <summary>
    /// Represents an instance of a cow.
    /// </summary>
    public class Cow : Animal
    {
        /// <summary>
        /// A constructor method that initializes most of the values for a cow.
        /// </summary>
        /// <param name="name">The cow's name.</param>
        public Cow(string name) : base(name)
        {
            AgeMonths = 0;
            Strength = 1;
            AverageLifespan = 176;
            PoundsOfFoodPerMonth = 810;
            MinimumSlaughterAge = 12;
            BestSlaughterAge = AverageLifespan * 0.15f;
            Products = new Dictionary<Product.Produce, float> { { Product.Produce.Milk, 0.0015f }, { Product.Produce.Butter, 0.0123f } };
            MeatType = Product.Produce.Beef;
            FoodType = Product.Food.Hay;
        }
    }
}
