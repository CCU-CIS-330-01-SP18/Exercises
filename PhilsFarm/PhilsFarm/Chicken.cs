using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsFarm
{
    /// <summary>
    /// Represents an instance of a chicken.
    /// </summary>
    public class Chicken : Animal
    {
        /// <summary>
        /// A constructor method that initializes most of the values for a chicken.
        /// </summary>
        /// <param name="name">The chicken's name.</param>
        public Chicken(string name) : base(name)
        {
            AgeMonths = 0;
            Strength = 1;
            AverageLifespan = 84;
            PoundsOfFoodPerMonth = 7.5f;
            MinimumSlaughterAge = 4;
            BestSlaughterAge = AverageLifespan * 0.15f;
            Products = new Dictionary<Product.Produce, float> { { Product.Produce.Eggs, 1 } };
            MeatType = Product.Produce.Chicken;
            FoodType = Product.Food.Grain;
        }
    }
}
