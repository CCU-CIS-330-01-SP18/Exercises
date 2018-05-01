using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Displays weapons in a weapon list to the console.
    /// </summary>
    public class DisplayItems
    {
        /// <summary>
        /// Prints the item number, name, and cost to the console, ordered by the cost from lowest to highest.
        /// </summary>
        /// <param name="list">The list whose elements are to be displayed.</param>
        public static void DisplayList(WeaponList<Weapon> list)
        {
            Console.WriteLine();
            Console.WriteLine("The total number of items is: " + list.Count());
            Console.WriteLine();

            // Use LINQ in parallell and utlilize the 'OrderBy' delegate to sort the list by cost from lowest to highest.
            var LinqSort = list.AsParallel().OrderBy(x => x.Cost).ToList();

            foreach (var item in LinqSort)
            {
                int itemNumber = LinqSort.IndexOf(item) + 1;
                Console.WriteLine("Item number: " + itemNumber);

                string name = item.Name;
                decimal cost = item.Cost;

                Console.WriteLine("Name: " + name);
                Console.WriteLine("Cost: $" + cost);
                Console.WriteLine();
            }
        }
    }
}
