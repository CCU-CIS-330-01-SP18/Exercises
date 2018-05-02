using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsFarm
{
    /// <summary>
    /// Represents an instance of a shop that you can buy animals from.
    /// </summary>
    public class AnimalShop
    {
        public Dictionary<Type, int> AnimalsForSale = new Dictionary<Type, int> { { typeof(Chicken), 3 }, { typeof(Cow), 500 }, { typeof(Sheep), 150 }, { typeof(Pig), 70 } };

        /// <summary>
        /// Purchases an amount of an animal type.
        /// </summary>
        /// <param name="roster">The roster to add the animals to.</param>
        /// <param name="animalType">The type of animal being purchased.</param>
        /// <param name="amount">The amount of animals being purchased.</param>
        public void BuyAnimal(FarmRoster roster, Type animalType, int amount)
        {
            var animals = new List<Animal>();
            for (int i = 1; i < amount + 1; i++)
            {
                bool assigned = false;
                while (!assigned)
                {
                    string userInput = UserInterface.AskUserForString($"What do you want to name {animalType.Name} number {i}? ");
                    if (!animals.Select(x => x.Name).Contains(userInput) && !roster.Animals.Select(x => x.Value.Name).Contains(userInput))
                    {
                        var newAnimal = (Animal)Activator.CreateInstance(animalType, userInput);
                        animals.Add(newAnimal);
                        roster.Cash -= AnimalsForSale[animalType];
                        assigned = true;
                    }
                    else
                    {
                        Console.WriteLine("That name has already been assigned.");
                    }
                }
            }

            foreach (var animal in animals)
            {
                roster.Animals.Add(animal.Name, animal);
            }
        }
    }
}
