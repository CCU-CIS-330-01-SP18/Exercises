using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace PhilsFarm
{
    /// <summary>
    /// Represents the way to extract information from a user.
    /// </summary>
    public static class UserInterface
    {
        private static TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;

        /// <summary>
        /// Asks the user a yes or no question.
        /// </summary>
        /// <param name="question">The question to ask the user.</param>
        /// <returns>The answer that the user gives.</returns>
        public static bool AskUserForBool(string question)
        {
            while (true)
            {
                Console.Write(question);
                switch (Console.ReadLine().ToUpper())
                {
                    case "YES":
                        return true;
                    case "NO":
                        return false;
                    default:
                        Console.WriteLine("Invalid Input. Your options are Yes or No");
                        break;
                }
            }
        }

        /// <summary>
        /// Asks the user a question that looks for a string as an answer.
        /// </summary>
        /// <param name="question">The question to ask the user.</param>
        /// <returns>The string that the user answered.</returns>
        public static string AskUserForString(string question)
        {
            while (true)
            {
                Console.Write(question);
                return Console.ReadLine().ToUpper();
            }
        }

        /// <summary>
        /// Asks the user a question that looks for an answer among an array of options.
        /// </summary>
        /// <param name="question">The question to ask the user.</param>
        /// <param name="options">The options to give the user.</param>
        /// <returns>The option that the user chose.</returns>
        public static string AskUserForOption(string question, string[] options)
        {
            string[] optionsUpper = options.Select(s => s.ToUpper()).ToArray();
            while (true)
            {
                Console.Write(question);
                string userInput = Console.ReadLine().ToUpper();
                if (optionsUpper.Contains(userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Your options are:");
                    foreach (string option in options)
                    {
                        Console.WriteLine($"{option}");
                    }
                }
            }
        }

        /// <summary>
        /// Asks the user for a float in a specific range.
        /// </summary>
        /// <param name="question">The question to ask the user.</param>
        /// <param name="minRange">The lowest acceptable value.</param>
        /// <param name="outOfMinRangeMessage">The message to give the user if they input a value below the minumum amount.</param>
        /// <param name="maxRange">The highest acceptable value.</param>
        /// <param name="outOfMaxRangeMessage">The message to give the user if they input a value above the maximum amount.</param>
        /// <returns>The value that the user chose.</returns>
        public static float AskUser(string question, float minRange, string outOfMinRangeMessage, float maxRange, string outOfMaxRangeMessage)
        {
            while (true)
            {
                Console.Write(question);
                string userInput = Console.ReadLine();

                if (!Regex.IsMatch(userInput, "^(\\d{1,5}|\\d{0,5}\\.\\d{1,2})$"))
                {
                    Console.WriteLine("Invalid Input. Write a float value.");
                }
                else
                {
                    float inputNumber = (float)Convert.ToDecimal(userInput);
                    if (inputNumber < minRange)
                    {
                        Console.WriteLine(outOfMinRangeMessage);
                    }
                    else if (inputNumber > maxRange)
                    {
                        Console.WriteLine(outOfMaxRangeMessage);
                    }
                    else
                    {
                        return inputNumber;
                    }
                }
            }
        }

        /// <summary>
        /// Asks the user for the name of a specific animal.
        /// </summary>
        /// <param name="question">The question to ask the user.</param>
        /// <param name="options">The animals to choose from.</param>
        /// <returns>The animal that the user selected.</returns>
        public static Animal AskUser(string question, Dictionary<string, Animal> options)
        {
            while (true)
            {
                Console.Write(question);
                try
                {
                    return options[Console.ReadLine().ToUpper()];
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid Input. Your options are:");
                    foreach (string key in options.Keys)
                    {
                        Console.WriteLine($"{key}");
                    }
                }
            }
        }

        /// <summary>
        /// Asks the user for the name of a specific produce item.
        /// </summary>
        /// <param name="question">The question to ask the user.</param>
        /// <param name="options">The list of produce options.</param>
        /// <returns>The produce item that the user selected.</returns>
        public static Product.Produce AskUser(string question, Product.Produce[] options)
        {
            while (true)
            {
                Console.Write(question);
                try
                {
                    var userInput = (Product.Produce)Enum.Parse(typeof(Product.Produce), TextInfo.ToTitleCase(Console.ReadLine().ToLower()));
                    if (options.Contains(userInput))
                    {
                        return  userInput;
                    }
                    else
                    {
                        Console.WriteLine("That product isn't an option.");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Input. Your options are:");
                    foreach (var key in options)
                    {
                        Console.WriteLine($"{key.ToString()}");
                    }
                }
            }
        }

        /// <summary>
        /// Asks the user for the name of a specific produce item.
        /// </summary>
        /// <param name="question">The question to ask the user.</param>
        /// <param name="options">The list of food options.</param>
        /// <returns>The selected food item.</returns>
        public static Product.Food AskUser(string question, Product.Food[] options)
        {
            while (true)
            {
                Console.Write(question);
                try
                {
                    var foodInput = (Product.Food)Enum.Parse(typeof(Product.Food), TextInfo.ToTitleCase(Console.ReadLine().ToLower()));
                    if (options.Contains(foodInput))
                    {
                        return foodInput;
                    }
                    else
                    {
                        Console.WriteLine("That product isn't an option.");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Input. Your options are:");
                    foreach (var key in options)
                    {
                        Console.WriteLine($"{key.ToString()}");
                    }
                }
            }
        }
    }
}
