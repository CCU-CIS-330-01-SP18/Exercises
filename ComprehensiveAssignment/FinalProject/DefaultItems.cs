using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Generates default data for the weapon store list.
    /// </summary>
    public class DefaultItems
    {
        /// <summary>
        /// Populates the weapon store list with default data.
        /// </summary>
        /// <returns>The list after it has been populated with the default values.</returns>
        public static WeaponList<Weapon> GenerateDefaultItems()
        {
            // Create the generic list of weapons.
            var list = new WeaponList<Weapon>();
            list.Add(new Weapon() { Name = "Great Axe", Cost = 4.0M });
            list.Add(new Weapon() { Name = "Sabre", Cost = 3.0M });
            list.Add(new Weapon() { Name = "Halbard", Cost = 5.0M });

            return list;
        }
    }
}
