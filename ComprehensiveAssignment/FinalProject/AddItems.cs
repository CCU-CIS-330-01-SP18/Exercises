using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// A class which implments the ability of a user to add items to a list.
    /// </summary>
    public class AddItems
    {
        /// <summary>
        /// A method which ensures that at every step of the data entry process, a valid value is provided.
        /// Then this method takes those values and adds them to the provided list.
        /// </summary>
        /// <param name="originalList">The list which will be added to.</param>
        /// <returns>The updated list with the new values.</returns>
        public static WeaponList<Weapon> AddItem(WeaponList<Weapon> originalList)
        {
            Console.WriteLine();
            Console.WriteLine("Let's add an item.");

            string typedCost;
            string typedName;

            // Keep the user here until they enter a correct username.
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please type the name of the item you would like to create. Only alphabet characters are permitted for this value.");

                typedName = Console.ReadLine();

                // Test to see if any errors were thrown, and if not break out of the loop.
                try
                {
                    bool success = AddNameOfItem(typedName);
                    break;
                }
                catch (ArgumentNullException error)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{error.GetType().Name}: You did not enter a value.");
                }
                catch (ArgumentOutOfRangeException error)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{error.GetType().Name}: You entered an invalid format for the name of the item. ");
                }
            }

            // Keep the user here until they enter a correct cost.
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Now please type the cost of the item you would like to create with numeric values only.");

                typedCost = Console.ReadLine();

                // Test to see if any errors were thrown, and if not break out of the loop.
                try
                {
                    bool success = AddCostOfItem(typedCost);
                    break;
                }
                catch (ArgumentNullException error)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{error.GetType().Name}: You did not enter a value.");
                }
                catch (ArgumentOutOfRangeException error)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{error.GetType().Name}: You entered an invalid format for the cost of the item. Please enter a decimal value.");
                }
            }

            // Add the created weapon.
            originalList.Add(new Weapon() { Name = typedName, Cost = Convert.ToDecimal(typedCost) });

            return originalList;
        }

        /// <summary>
        /// Checks the user input for the name of an item to ensure its validity.
        /// </summary>
        /// <param name="typedName">The value provided by the user for the name of the item.</param>
        /// <returns>Either an error symbolizing the name is not valid, or true, symbolizing it is valid.</returns>
        public static bool AddNameOfItem(string typedName)
        {
            // This cleans the typedName field so that all spaces are removed.
            typedName = Regex.Replace(typedName, @"\s+", string.Empty);

            // Ensure that the field meets the regex requirements of containing only letter.
            bool nameIsCorrect = Regex.IsMatch(typedName, @"^[a-z, A-Z]+$");

            if (nameIsCorrect)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(typedName))
            {
                throw new ArgumentNullException();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Checks the user input for the cost of an item to ensure its validity.
        /// </summary>
        /// <param name="typedCost">The value provided by the user for the name of the item.</param>
        /// <returns>Either an error symbolizing the cost is not valid, or true, symbolizing it is valid.</returns>
        public static bool AddCostOfItem(string typedCost)
        {
            // Ensure that the field meets the regex requirements of containing only letters.
            bool costIsCorrect = Regex.IsMatch(typedCost, @"^\d+([.]\d{1,2})?$");

            if (costIsCorrect)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(typedCost))
            {
                throw new ArgumentNullException();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
