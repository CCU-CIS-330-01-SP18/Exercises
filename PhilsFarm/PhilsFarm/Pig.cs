using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsFarm
{
    /// <summary>
    /// Represents an instance of a pig.
    /// </summary>
    public class Pig : Animal
    {
        /// <summary>
        /// A constructor method that initializes most of the values for a pig.
        /// </summary>
        /// <param name="name">The pig's name.</param>
        public Pig(string name) : base(name)
        {
            AgeMonths = 0;
            Strength = 1;
            AverageLifespan = 96;
            PoundsOfFoodPerMonth = 240;
            MinimumSlaughterAge = 12;
            BestSlaughterAge = AverageLifespan / 2;
            MeatType = Product.Produce.Bacon;
            FoodType = Product.Food.Grain;
        }
    }
}
