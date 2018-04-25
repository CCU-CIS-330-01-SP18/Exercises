using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Contains an application which allows the user to access and add items to a weapon's store.
    /// </summary>
    public class WeaponShop
    {
        /// <summary>
        /// This is the method which starts the console application.
        /// </summary>
        /// <param name="args">The arguments which the Main method can utilize.</param>
        public static void Main(string[] args)
        {
            // Ensures that the person logging in is the admin.
            AdministrationLogin.AdminLogin();

            var list = LoadNecessaryItems();

            // Show the list on the console.
            DisplayItems.DisplayList(list);

            // See if the user wants to add any items to the store.
            AddItemsPrompt(list);

        }

        /// <summary>
        /// If the weapon store file exists, pull that file and use it.
        /// If the file does not exist, create the starter items and generate the file.
        /// </summary>
        /// <returns>The list of starter items.</returns>
        public static WeaponList<Weapon> LoadNecessaryItems()
        {
            if (File.Exists("_WeaponShopList.txt"))
            {
                // If the file exists, deserialize it.
                var list = SerializeAndDeserialize.DeserializeWeaponList("_WeaponShopList.txt");

                return list;
            }
            else
            {
                // Create the default items.
                var list = DefaultItems.GenerateDefaultItems();

                // Serialize the items.
                SerializeAndDeserialize.SerializeWeaponList(list, "_WeaponShopList.txt");

                return list;
            }
        }


        /// <summary>
        /// Allows the user to add items to the list of current items and prints the result.
        /// </summary>
        /// <param name="originalList">The list which was pulled from the weapons list file</param>
        public static void AddItemsPrompt(WeaponList<Weapon> originalList)
        {
            // Keep the user here until he/she is done adding items.
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("If you would like to add another item to the list, type 'Yes'.");
                Console.WriteLine("If the list is complete and you would like to save the list, enter anything else.");

                string response = Console.ReadLine();

                if (response == "Yes" || response == "yes")
                {
                    // Update the original list with the new item that the user added.
                    originalList = AddItems.AddItem(originalList);
                }
                else
                {
                    break;
                }
            }

            // Save the updated list and display it to the console.
            var updatedList = SaveTheNewList(originalList, "_WeaponShopList.txt");
            DisplayItems.DisplayList(updatedList);
        }

        /// <summary>
        /// Deletes the current weapons list file, and creates and updated one.
        /// </summary>
        /// <param name="newList">The new list which is to be saved.</param>
        /// <param name="path">The path to the file which holds the serialized list.</param>
        /// <returns>The deserialized version of the list which was saved.</returns>
        public static WeaponList<Weapon> SaveTheNewList(WeaponList<Weapon> newList, string path)
        {
            File.Delete(path);

            // Serialize the items.
            SerializeAndDeserialize.SerializeWeaponList(newList, path);

            // Deserialize the list of items.
            var updatedList = SerializeAndDeserialize.DeserializeWeaponList(path);

            return updatedList;
        }

    }
}
