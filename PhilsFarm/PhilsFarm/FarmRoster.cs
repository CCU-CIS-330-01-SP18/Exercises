using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PhilsFarm
{
    /// <summary>
    /// Represents an instance of the resources that the user has collected.
    /// </summary>
    public class FarmRoster
    {
        public float Cash = 1000;
        public int MonthNumber = 1;
        public Dictionary<string, Animal> Animals = new Dictionary<string, Animal> { };
        public Dictionary<Product.Produce, float> ProduceAmount = new Dictionary<Product.Produce, float> { { Product.Produce.Eggs, 0 }, { Product.Produce.Chicken, 0 }, { Product.Produce.Milk, 0 }, { Product.Produce.Butter, 0 }, { Product.Produce.Beef, 0 }, { Product.Produce.Wool, 0 }, { Product.Produce.Lamb, 0 }, { Product.Produce.Bacon, 0 } };
        public Dictionary<Product.Food, float> FoodAmount = new Dictionary<Product.Food, float> { { Product.Food.Grain, 0 }, { Product.Food.Hay, 0 } };

        private string SaveFileLocation = AppDomain.CurrentDomain.BaseDirectory;
        private JsonSerializerSettings JSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        /// <summary>
        /// Saves the current FarmRoster object to a file in JSON format.
        /// </summary>
        /// <param name="fileName">The name of the save.</param>
        public void SaveFile(string fileName)
        {
            string serializedSave = JsonConvert.SerializeObject(this, JSettings);
            File.WriteAllText(SaveFileLocation + fileName + ".json", serializedSave);
        }

        /// <summary>
        /// Loads a JSON file and attempts to parse it as a FarmRoster instance.
        /// </summary>
        /// <param name="fileName">The name of the file to load.</param>
        /// <returns>A bool indicative of success or failture to load the file.</returns>
        public bool LoadFile(string fileName)
        {
            if (File.Exists(SaveFileLocation + fileName + ".json"))
            {
                try
                {
                    string productsText = File.ReadAllText(SaveFileLocation + fileName + ".json");
                    var saveData = JsonConvert.DeserializeObject<FarmRoster>(productsText, JSettings);
                    Cash = saveData.Cash;
                    MonthNumber = saveData.MonthNumber;
                    Animals = saveData.Animals;
                    ProduceAmount = saveData.ProduceAmount;
                    FoodAmount = saveData.FoodAmount;

                    Console.WriteLine("Save data loaded.");
                    return true;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("You do not have authorization to access that file.");
                    return false;
                }
                catch (JsonException)
                {
                    Console.WriteLine("Error deserializing file.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("That file does not exist.");
                return false;
            }
        }
    }
}
