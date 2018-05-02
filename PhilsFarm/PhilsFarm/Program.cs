using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PhilsFarm
{
    /// <summary>
    /// The main interface between the user and the rest of the game.
    /// </summary>
    class Program
    {
        private static MarketConnection Market = new MarketConnection();
        private static AnimalShop Shop = new AnimalShop();
        private static FarmRoster Roster = new FarmRoster();
        private static TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;

        /// <summary>
        /// The automagically-run method that the console calls.
        /// </summary>
        /// <param name="args">A generic array of arguments.</param>
        static void Main(string[] args)
        {
            LoadGameFile();
            DisplayFarmMenu();
        }

        /// <summary>
        /// Saves the current game.
        /// </summary>
        private static void SaveGame()
        {
            Roster.SaveFile(UserInterface.AskUserForString("Name your save file (this will overwrite saves that have the same name): "));
            Console.WriteLine("File Saved!");
        }

        /// <summary>
        /// Loads a saved game file.
        /// </summary>
        private static void LoadGameFile()
        {
            if (UserInterface.AskUserForBool("Would you like to load a saved game? "))
            {
                while (true)
                {
                    if (!Roster.LoadFile(UserInterface.AskUserForString("What is the name of the save? ")))
                    {
                        if (!UserInterface.AskUserForBool("Would you like to try again? "))
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Displays the farm interface.
        /// </summary>
        private static void DisplayFarmMenu()
        {
            while (true)
            {
                switch (UserInterface.AskUserForOption("You're on the farm. What would you like to do? ", new string[] { "Go To Animals", "Check Roster", "Buy Animals", "Go To Market", "Hibernate", "Save Game", "Quit" }))
                {
                    case "GO TO ANIMALS":
                        CheckAnimals();
                        break;
                    case "CHECK ROSTER":
                        CheckRoster();
                        break;
                    case "BUY ANIMALS":
                        BuyAnimals();
                        break;
                    case "GO TO MARKET":
                        GoToMarket();
                        break;
                    case "HIBERNATE":
                        Hibernate();
                        break;
                    case "SAVE GAME":
                        SaveGame();
                        break;
                    case "QUIT":
                        return;
                }
            }
        }

        /// <summary>
        /// Passes one month of time, during whcih the user feeds their animals, their animals grow (and sometimes die), and the market shifts.
        /// </summary>
        private static void Hibernate()
        {
            Console.WriteLine("You settle in for a month. Decide how to feed each of your animals.");
            Market.MoveMarket().Wait();
            // I had to iterate through a something besides Roster.Animals because the death of animals screws up foreach enumeration on the actual instance.
            string[] animalRosterNames = Roster.Animals.Keys.ToArray();
            for(int index = animalRosterNames.Length - 1; index >= 0; index--)
            {
                var animal = Roster.Animals[animalRosterNames[index]];
                animal.Feed(Roster, UserInterface.AskUser($"How much food do you want to give {animal.Name} the {animal.GetType().Name}? (they require {animal.PoundsOfFoodPerMonth} pounds of food per month to be satisfied.)", 0, "You cannot extract food from an animal.", animal.PoundsOfFoodPerMonth, $"{animal.Name} doesn't need more than {animal.PoundsOfFoodPerMonth} pounds of food."));
            }
            TravelDelay();
            Roster.MonthNumber++;
            Console.WriteLine($"Month {Roster.MonthNumber - 1} has passed. Welcome to month {Roster.MonthNumber}!");
        }

        /// <summary>
        /// Displays the marketplace interface.
        /// </summary>
        private static void GoToMarket()
        {
            Console.WriteLine("You leave the comfort of your farm to face the dangers of the big city market.");
            TravelDelay();
            Console.WriteLine(" Huzzah! You've made it to the big city!");
            while (true)
            {
                switch (UserInterface.AskUserForOption("You're at the market. What do you want to do? ", new string[] { "Get Prices", "Sell", "Buy", "Leave" }))
                {
                    case "GET PRICES":
                        GetPrices();
                        break;
                    case "SELL":
                        StartSelling();
                        break;
                    case "BUY":
                        StartBuying();
                        break;
                    case "LEAVE":
                        Console.WriteLine("You begin the journey back to your farm.");
                        TravelDelay();
                        Console.WriteLine("You make it back, safe and sound.");
                        return;
                }
            }
        }

        // Yes, the mistake of separating food and products in this way is really biting me in the rear right now. I'm starved for time, so I'm being lazy.
        /// <summary>
        /// Continues the process of selling a product.
        /// </summary>
        private static async void SellProduct()
        {
            var productToSell = UserInterface.AskUser("Which product would you like to sell? ", Roster.ProduceAmount.Keys.ToArray());
            float currentPrice = Market.GetProducts(TextInfo.ToTitleCase(productToSell.ToString().ToLower())).Result.MarketPrice;
            Console.WriteLine($"That product is currently going for ${currentPrice}.");
            float quantityToSell = UserInterface.AskUser($"How many pounds of {productToSell.ToString()} would you like to sell? ", 0, "Use the buy option for that.", Roster.ProduceAmount[productToSell], $"You only have {Roster.ProduceAmount[productToSell]} pounds to sell.");

            if (UserInterface.AskUserForBool($"Are you sure you want to sell {quantityToSell} pounds of {productToSell.ToString()} for ${quantityToSell * currentPrice}? "))
            {
                await Market.SellProduct(productToSell.ToString(), quantityToSell);
                Roster.ProduceAmount[productToSell] -= quantityToSell;
                Roster.Cash += quantityToSell * currentPrice;
            }
            else
            {
                Console.WriteLine("You decided against selling your product.");
            }
        }

        /// <summary>
        /// Begins the process of selling food.
        /// </summary>
        private static async void SellFood()
        {
            var foodToSell = UserInterface.AskUser("Which food would you like to sell? ", Roster.FoodAmount.Keys.ToArray());
            float currentPrice = Market.GetProducts(TextInfo.ToTitleCase(foodToSell.ToString().ToLower())).Result.MarketPrice;
            Console.WriteLine($"That food is currently going for ${currentPrice}.");
            float quantityToSell = UserInterface.AskUser($"How many pounds of {foodToSell.ToString()} would you like to sell? ", 0, "Use the buy option for that.", Roster.FoodAmount[foodToSell], $"You only have {Roster.FoodAmount[foodToSell]} pounds to sell.");

            if (UserInterface.AskUserForBool($"Are you sure you want to sell {quantityToSell} pounds of {foodToSell.ToString()} for ${quantityToSell * currentPrice}? "))
            {
                await Market.SellProduct(foodToSell.ToString(), quantityToSell);
                Roster.FoodAmount[foodToSell] -= quantityToSell;
                Roster.Cash += quantityToSell * currentPrice;
            }
            else
            {
                Console.WriteLine("You decided against selling your food.");
            }
        }
        /// <summary>
        /// Continues the process of buying an item.
        /// </summary>
        /// <param name="name">The name of the product that the user is interested in.</param>
        private static async void BuyItem(string name)
        {
            float currentPrice = Market.GetProducts(name).Result.MarketPrice;
            Console.WriteLine($"That item is currently going for ${currentPrice}.");
            float quantityToBuy = UserInterface.AskUser($"How many pounds of {name} would you like to buy? ", 0, "Use the sell option for that.", Roster.Cash / currentPrice, $"You can only buy {Roster.Cash / currentPrice} pounds at most.");

            if (UserInterface.AskUserForBool($"Are you sure you want to buy {quantityToBuy} pounds of {name} for ${quantityToBuy * currentPrice}? "))
            {
                await Market.BuyProduct(name, quantityToBuy);

                if (Enum.TryParse(name, out Product.Produce product))
                {
                    Roster.ProduceAmount[product] += quantityToBuy;
                }
                else if (Enum.TryParse(name, out Product.Food food))
                {
                    Roster.FoodAmount[food] += quantityToBuy;
                }

                Roster.Cash -= quantityToBuy * currentPrice;
            }
            else
            {
                Console.WriteLine($"You decided against buying {name}.");
            }
        }

        /// <summary>
        /// Begins the process of selling an item.
        /// </summary>
        private static void StartSelling()
        {
            while (true)
            {
                switch (UserInterface.AskUserForOption("Would you like to sell a product or food item? ", new string[] { "Product", "Food", "Stop" }))
                {
                    case "PRODUCT":
                        SellProduct();
                        break;
                    case "FOOD":
                        SellFood();
                        break;
                    case "STOP":
                        return;
                }
            }
        }

        /// <summary>
        /// Begins the process of buying an item.
        /// </summary>
        private static void StartBuying()
        {
            var marketItems = Market.GetProducts().Result;
            List<string> marketItemNames = marketItems.Select(x => x.Name).ToList();
            marketItemNames.Add("STOP");
            while (true)
            {
                string userInput = UserInterface.AskUserForOption("What item would you like to buy? ", marketItemNames.ToArray());
                if (userInput != "STOP")
                {
                    BuyItem(TextInfo.ToTitleCase(userInput.ToLower()));
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Writes the prices of all the items on the market to the console.
        /// </summary>
        private static void GetPrices()
        {
            foreach (var product in Market.GetProducts().Result)
            {
                Console.WriteLine($"Today's market price for {product.Name} is ${Math.Round(product.MarketPrice, 2)}.");
            }
        }

        /// <summary>
        /// Simulates time passing for the sake of ultra-realism.
        /// </summary>
        private static void TravelDelay()
        {
            Console.WriteLine("");
            for (int i = 3; i > 0; i--)
            {
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
            }
            System.Threading.Thread.Sleep(1000);
        }
         /// <summary>
         /// Begin the process of buying animals.
         /// </summary>
        private static void BuyAnimals()
        {
            var animalsForSale = Shop.AnimalsForSale.Keys.ToArray().Select(t => t.Name).ToList();
            animalsForSale.Add("LEAVE");

            Console.WriteLine($"Howdy! My prices today are the best they've ever been, and the worst they'll ever be.");
            foreach (var animalType in Shop.AnimalsForSale.Keys)
            {
                Console.WriteLine($"For one {animalType.Name} it'll cost you ${Shop.AnimalsForSale[animalType]}.");
            }

            while (true)
            {
                switch (UserInterface.AskUserForOption("What kind of animal would you like to buy? ", animalsForSale.ToArray()))
                {
                    case "CHICKEN":
                        PurchaseAnimal(typeof(Chicken));
                        break;
                    case "COW":
                        PurchaseAnimal(typeof(Cow));
                        break;
                    case "SHEEP":
                        PurchaseAnimal(typeof(Sheep));
                        break;
                    case "PIG":
                        PurchaseAnimal(typeof(Pig));
                        break;
                    case "LEAVE":
                        return;
                }
            }
        }

        /// <summary>
        /// Attempts to purchase an animal.
        /// </summary>
        /// <param name="animalType"></param>
        private static void PurchaseAnimal(Type animalType)
        {
            if (Roster.Cash < Shop.AnimalsForSale[animalType])
            {
                Console.WriteLine($"You'd better stop eyeing that {animalType.Name}, I know you can't afford it.");
                return;
            }
            else
            {
                Shop.BuyAnimal(Roster, animalType, (int)UserInterface.AskUser($"How many {animalType.Name}s will you be buying today? ", 0, "I'm only in the selling business.", (Roster.Cash / Shop.AnimalsForSale[animalType] - (Roster.Cash % Shop.AnimalsForSale[animalType]) / Shop.AnimalsForSale[animalType]), "Looks like you're a little short on cash there."));
            }
        }

        /// <summary>
        /// Writes information about the current roster instance.
        /// </summary>
        private static void CheckRoster()
        {
            Console.WriteLine($"It is month {Roster.MonthNumber} and you have ${Math.Round(Roster.Cash, 2)}.");
            Console.WriteLine($"You have {Roster.Animals.Count} animals.");
            foreach (Product.Produce product in Roster.ProduceAmount.Keys)
            {
                Console.WriteLine($"You have {Math.Round(Roster.ProduceAmount[product], 2)} pounds of {product}.");
            }
            foreach (Product.Food food in Roster.FoodAmount.Keys)
            {
                Console.WriteLine($"You have {Math.Round(Roster.FoodAmount[food], 2)} pounds of {food}.");
            }
        }
        
        /// <summary>
        /// Approaches the current lovestock thst the player owns.
        /// </summary>
        private static void CheckAnimals()
        {
            while (true)
            {
                switch (UserInterface.AskUserForOption($"You're {(Roster.Animals.Count == 0 ? "alone in the place that your animals should be." : "with your animals.")} What would you like to do? ", new string[] { "Look", "Get Products", "Slaughter", "Leave" }))
                {
                    case "LOOK":
                        if (Roster.Animals.Count == 0)
                        {
                            Console.WriteLine("You have no animals to look at. You feel lonely.");
                        }
                        else
                        {
                            LookAtYourAnimals();
                        }
                        break;
                    case "GET PRODUCTS":
                        if (Roster.Animals.Count == 0)
                        {
                            Console.WriteLine("You have no animals to get products from. You feel lonely.");
                        }
                        else
                        {
                            GetProduceFromAnimal();
                        }
                        break;
                    case "SLAUGHTER":
                        if (Roster.Animals.Count == 0)
                        {
                            Console.WriteLine("You have no animals to slaughter. You feel lonely and a tad psychotic.");
                        }
                        else
                        {
                            SlaughterAnimal();
                        }
                        break;
                    case "LEAVE":
                        return;
                }
            }
        }

        /// <summary>
        /// Attempts to slaughter an animal.
        /// </summary>
        private static void SlaughterAnimal()
        {
            var options = Roster.Animals.Keys.ToList();
            options.Add("None");

            string userInput = UserInterface.AskUserForOption("Which animal would you like to slaughter, if any? ", options.ToArray());
            if (userInput == "NONE")
            {
                return;
            }
            else if (UserInterface.AskUserForBool($"{Roster.Animals[userInput].Name} is {Roster.Animals[userInput].AgeMonths} months old. Would you like to slaughter it? "))
            {
                Roster.Animals[userInput].Slaughter(Roster);
            }
        }
        /// <summary>
        /// Attemptes to retrieve produce from an animal.
        /// </summary>
        private static void GetProduceFromAnimal()
        {
            while (true)
            {
                var options = Roster.Animals.Keys.ToList();
                options.Add("None");

                string userInput = UserInterface.AskUserForOption("Which animal would you like to get products from, if any? ", options.ToArray());
                if (userInput == "NONE")
                {
                    return;
                }

                var animal = Roster.Animals[userInput];

                if (animal.Growth < animal.Products.Values.Min())
                {
                    Console.WriteLine($"{animal.Name} doesn't have enough growth to produce anything.");
                }
                else
                {
                    var animalProducts = animal.Products.Keys.ToArray();
                    animal.ProduceProduct(Roster, UserInterface.AskUser($"Which product would you like to produce from {animal.Name}? ", animalProducts), UserInterface.AskUser($"How much growth would you like to spend from {animal.Name}'s {animal.Growth} growth? ", 0, "You must spend growth to create products.", animal.Growth, $"{animal.Name} doesn't have that much growth."));
                }
            }
        }

        /// <summary>
        /// Retrieves information about the current roster's animals.
        /// </summary>
        private static void LookAtYourAnimals()
        {
            int chickenCount = 0, cowCount = 0, sheepCount = 0, pigCount = 0;
            foreach (var animal in Roster.Animals)
            {
                switch (animal.Value.GetType().Name)
                {
                    case "Chicken":
                        chickenCount++;
                        break;
                    case "Cow":
                        cowCount++;
                        break;
                    case "Sheep":
                        sheepCount++;
                        break;
                    case "Pig":
                        pigCount++;
                        break;
                }
            }
            Console.WriteLine($"You have {chickenCount} chicken{(chickenCount != 1 ? "s" : "")}, {cowCount} cow{(cowCount != 1 ? "s" : "")}, {sheepCount} sheep, and {pigCount} pig{(pigCount != 1 ? "s" : "")}.");
            switch (UserInterface.AskUserForOption("Would you like to inspect them closer? Which type of animal? ", new string[] { "Chicken", "Cow", "Sheep", "Pig", "No" }))
            {
                case "CHICKEN":
                    GetAnimalNames(typeof(Chicken), chickenCount);
                    break;
                case "COW":
                    GetAnimalNames(typeof(Cow), cowCount);
                    break;
                case "SHEEP":
                    GetAnimalNames(typeof(Sheep), sheepCount);
                    break;
                case "PIG":
                    GetAnimalNames(typeof(Pig), pigCount);
                    break;
                case "NO":
                    return;
            }
        }

        /// <summary>
        /// Retrieves the names of the chosen type of animal in the roster.
        /// </summary>
        /// <param name="animalType">The type of animal to get the names of.</param>
        /// <param name="animalCount">The amount of animals of that type in the roster.</param>
        private static void GetAnimalNames(Type animalType, int animalCount)
        {
            Console.WriteLine($"You remember your {animalCount} {animalType.Name}'s name{(animalCount != 1 ? "s" : "")}. {(animalCount != 1 ? "They are" : "It is")}");

            foreach (var animal in Roster.Animals.Where(a => a.Value.GetType() == animalType))
            {
                Console.WriteLine(animal.Key);
            }

            while (true)
            {
                if (UserInterface.AskUserForBool("Do you want to inspect a particular animal? "))
                {
                    GetAnimalDetails(UserInterface.AskUser("Which one? ", Roster.Animals).Name);
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Writes detailed information on one named animal.
        /// </summary>
        /// <param name="name">The name of the animal to write information on.</param>
        private static void GetAnimalDetails(string name)
        {
            var animal = Roster.Animals[name];
            // Sorry about this.
            Console.WriteLine($"{(animal.AgeMonths < animal.AverageLifespan * 0.15 ? $"Ahh {animal.Name}. Still so young." : $"{animal.Name} has matured.")} It is {animal.AgeMonths} months old.");
            Console.WriteLine($"{(animal.AgeMonths < animal.MinimumSlaughterAge ? "It does not look even close to being ready to be slaughtered." : (animal.AgeMonths < animal.BestSlaughterAge ? $"It's getting close to the ripest time to slaughter {animal.Name}." : (animal.AgeMonths > animal.BestSlaughterAge ? $"Though {animal.Name}'s ripest ages are past, it still could render good meat." : (animal.AgeMonths > animal.AverageLifespan ? "It's much too old to be slaughtered." : "It looks like the perfect time to slaughter it."))))}");
            Console.WriteLine($"{animal.Name} {(animal.MonthsStarved > 0 ? $"has lost {animal.MonthsStarved} months of its life to starvation " : "has been well fed its whole life.")}");
            Console.WriteLine($"{animal.Name} {(animal.Strength == 1 ? "is in excellent health." : (animal.Strength > 0.75 ? "is in an average state of health." : (animal.Strength > 0.5 ? "is doing quite poorly in terms of health." : (animal.Strength > 0.25 ? "is looing deathly weak." : "is on the verge of death. It's a miracle that it has survived this long."))))}");
            Console.WriteLine($"{animal.Name} has {animal.Growth} growth points.");
        }
    }
}
