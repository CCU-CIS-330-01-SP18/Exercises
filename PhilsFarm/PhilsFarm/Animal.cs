using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsFarm
{
    /// <summary>
    /// Represents a generic animal that can be raised on the farm.
    /// </summary>
    public abstract class Animal
    {
        public string Name { get; set; }
        public int AgeMonths { get; set; }
        public float Strength { get; set; }
        public int AverageLifespan { get; set; }
        public float MinimumSlaughterAge { get; set; }
        public float BestSlaughterAge { get; set; }
        public float Growth { get; set; }
        public float MonthsWithoutFood { get; set; }
        public float MonthsWithFood { get; set; }
        public float MonthsStarved { get; set; }
        public float PoundsOfFoodPerMonth { get; set; }
        public Dictionary<Product.Produce, float> Products { get; protected set; }
        public Product.Produce MeatType { get; protected set; }
        public Product.Food FoodType { get; protected set; }

        /// <summary>
        /// Creates an instance of an animal with a name.
        /// </summary>
        /// <param name="name">The name to give the animal.</param>
        public Animal(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gives the user a spectrum of options in terms of how well they will take care of it.
        /// </summary>
        /// <param name="roster">The roster to feed the animal from.</param>
        /// <param name="amountToFeed">The amount to feed the animal.</param>
        public void Feed(FarmRoster roster, float amountToFeed)
        {
            roster.FoodAmount[FoodType] -= amountToFeed;
            Live(amountToFeed, roster);
        }

        /// <summary>
        /// Attempts to produce an amount of product from an animal in exchange for its growth points.
        /// </summary>
        /// <param name="roster">The roster to add the product to.</param>
        /// <param name="product">The product to produce.</param>
        /// <param name="growthSpent">The amount of growth to spend on production.</param>
        public void ProduceProduct(FarmRoster roster, Product.Produce product, float growthSpent)
        {
            try
            {
                float productReturnAmount = growthSpent / Products[product];

                roster.ProduceAmount[product] += productReturnAmount;
                Growth -= growthSpent;

                Console.WriteLine($"{productReturnAmount} pounds of {product.ToString()} were produced.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"{Name} cannot produce that product.");
            }
        }

        /// <summary>
        /// Ages an animal and either bolsters or diminishes their health.
        /// </summary>
        /// <param name="foodConsumed">The amount of food that this animal ate.</param>
        /// <param name="roster">The roster from which to retrieve the food.</param>
        private void Live(float foodConsumed, FarmRoster roster)
        {
            float extraAgeIncrease = (float)Math.Round(Math.Pow(MonthsWithoutFood, 1.5) * ((PoundsOfFoodPerMonth - foodConsumed) / PoundsOfFoodPerMonth), 2);
            float growingDone = (float)Math.Round((foodConsumed / PoundsOfFoodPerMonth) * Strength, 2);

            MonthsWithFood = foodConsumed < PoundsOfFoodPerMonth ? 0 : MonthsWithFood + 1;
            MonthsWithoutFood += foodConsumed == PoundsOfFoodPerMonth ? -MonthsWithoutFood : (PoundsOfFoodPerMonth - foodConsumed) / PoundsOfFoodPerMonth;
            MonthsStarved += extraAgeIncrease;
            Strength += (MonthsWithFood - MonthsWithoutFood * 1.5f) / (AverageLifespan / 10);
            Strength = Strength > 1 ? 1 : Strength;
            Growth += growingDone;
            AgeMonths++;

            // Sorry for this nasty nested ternary expression.
            Console.WriteLine($"{Name} was fed {(foodConsumed < PoundsOfFoodPerMonth ? foodConsumed == 0 ? $"nothing and lost {extraAgeIncrease} months of its life." : Convert.ToString(foodConsumed) + $" pounds of food and lost {extraAgeIncrease} months of its life." : "adequately.")}");

            if (Strength <= 0)
            {
                DieFrom("starvation", roster);
            }
            else if (!DeathChance("natural causes", roster))
            {
                Console.WriteLine($"{Name} survived and gained {growingDone} growth.");
            }
        }

        /// <summary>
        /// Slaughters an animal for meat-gain.
        /// </summary>
        /// <param name="roster">The roster to add the meat to.</param>
        public void Slaughter(FarmRoster roster)
        {
            float baseMeatYield = PoundsOfFoodPerMonth / 2;

            // Finds a number between 0 and 1.25 on an asymmetric parabola curve from 0 at the minimum slaughter age to 1.25 at the best slaughter age and back to 0 at 110% of the average lifespan.
            float agePotencyMultiplier = AgeMonths < MinimumSlaughterAge ? 0 : AgeMonths < BestSlaughterAge ? GetAgePotency(BestSlaughterAge - MinimumSlaughterAge) : GetAgePotency((float)(AverageLifespan * 1.1) - BestSlaughterAge);
            float agePotency = -agePotencyMultiplier * (float)Math.Pow((AgeMonths - BestSlaughterAge), 2) + 1.25f;

            float healthPotency = (MonthsWithFood - MonthsStarved * 2) / AgeMonths;

            float actualMeatYield = baseMeatYield * agePotency + (baseMeatYield * healthPotency);

            roster.ProduceAmount[MeatType] += actualMeatYield;

            Console.WriteLine($"You slaughtered {Name} for {actualMeatYield} pounds of {MeatType}. Their health {(healthPotency < 0 ? "negatively affected" : "positively affected")} the yield by {Math.Round(healthPotency, 2)}%, and their age multiplier was {agePotency}.");
            DieFrom("being slaughtered", roster);
        }

        /// <summary>
        /// Randomly gives the animal a chance of death depending on its current state.
        /// </summary>
        /// <param name="cause">The reason why death is getting a chance to knock at this animal's metaphorical door.</param>
        /// <param name="roster">The roster to remove the animal from if it does perish.</param>
        /// <returns></returns>
        private bool DeathChance(string cause, FarmRoster roster)
        {
            // A nice little math thingy to estimate the condition of an animal.
            float chanceOfDeath = (AgeMonths + (MonthsStarved * 1.5f) - AverageLifespan + (AverageLifespan * 0.1f)) / (AverageLifespan * 0.8f) + (1 - Strength);

            // A cryptographically secure random number generator. Wouldn't want anyone to be able to predict it for obvious reasons.
            using (var random = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[2];
                random.GetBytes(randomBytes);
                float randomFloat = (float)BitConverter.ToInt16(randomBytes, 0) / UInt16.MaxValue;

                if (randomFloat < chanceOfDeath)
                {
                    DieFrom(cause, roster);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Kills an animal.
        /// </summary>
        /// <param name="causeOfDeath">The reason why this animal has died.</param>
        /// <param name="roster">The roster to remove this animal from.</param>
        private void DieFrom(string causeOfDeath, FarmRoster roster)
        {
            Console.WriteLine($"{Name} has died from {causeOfDeath}. {(MonthsStarved > 0 ? $"It had lost {Math.Round(MonthsStarved / (AgeMonths + MonthsStarved), 2)}% of its life from starvation." : "It was well taken care of.")}");
            roster.Animals.Remove(Name);
        }

        /// <summary>
        /// A helper method to retreive a value from a point along an asymptote.
        /// </summary>
        /// <param name="MonthDistance">The distance in months from an animal's BestSlaughterAge to make the AgePotency zero.</param>
        /// <returns>A point along an asymptote.</returns>
        private float GetAgePotency(float MonthDistance)
        {
            return (5 * (float)Math.Pow(MonthDistance, -2)) / 4;
        }
    }
}
