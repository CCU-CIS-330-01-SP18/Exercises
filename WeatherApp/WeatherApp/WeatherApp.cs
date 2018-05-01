using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace WeatherApp
{
    /// <summary>
    /// Class that represents the entry point of Weather App.
    /// </summary>
    public class WeatherApp
    {
        public delegate void Del(string message);

        /// <summary>
        /// A wonderful implementation of a delegate to print messages to the console.
        /// </summary>
        /// <param name="message">String to be printed.</param>
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Entry point of Weather App.
        /// </summary>
        /// <param name="args">Data entered in the console.</param>
        static void Main(string[] args)
        {
            Del print = Print;
            string loginDecision;
            string username;
            string password;
            byte[] hashedPassword;
            bool isVerified = false;
            bool canContinue = false;
            RootObject weatherData;

            print("************************************");
            print("****Welcome to Your Weather App!****");
            print("************************************");
            print("          --Login Menu--");
            
            while (true)
            {
                print("Would you like to Login?");
                print("('Yes' for login, 'No' for account creation.)");
                try
                {
                    loginDecision = Console.ReadLine();
                }
                catch(System.Exception e)
                {
                    loginDecision = "";
                    print(e.ToString());
                }

                
                if (loginDecision == "Yes" || loginDecision == "yes" || loginDecision == "y")
                {
                    while (isVerified == false)
                    {
                        //Get login info from user.
                        print("\r\n Enter Username:");
                        username = Console.ReadLine();
                        print("\r\n Enter Password:");
                        password = Console.ReadLine();

                        //Hash input password.
                        hashedPassword = HashPassword(password);

                        //Verify user data.
                        isVerified = VerifyLogin(username, hashedPassword);
                        if(isVerified == true)
                        {
                            print("verified");

                            while (canContinue == false)
                            {
                                try
                                {
                                    weatherData = GetWeather.APIcall(GetWeather.GetCity()).Result;
                                }
                                catch (Exception e)
                                {
                                    weatherData = null;
                                    print("API call failure.");
                                    print(e.ToString());
                                }

                                canContinue = weatherData.GenerateReport();
                            }
                            //End of Application
                            Environment.Exit(0);
                        }
                        else
                        {
                            print("Username or Password is incorrect, or doesnt exist.");
                        }
                    }

                }
                else if (loginDecision == "No" || loginDecision == "no" || loginDecision == "n")
                {
                    //Create new account.
                    AccountCreation();
                }
                else
                {
                    print("Invalid Input");
                }
            }
        }

        /// <summary>
        /// Facilitates Account Creation.
        /// </summary>
        public static void AccountCreation()
        {
            Del print = Print;
            bool isMatched = false;
            string newUsername;
            string newPassword;
            byte[] hashedPassword;
            var entry = new Dictionary<string,byte[]>();
            var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

            //Get account data from user.
            print("----Acount Creation Menu----");
            print("\r\n Enter New Username:");
            
            newUsername = Console.ReadLine();
            while (isMatched != true)
            {
                print("\r\n Enter New Password: (Must be at least 8 digits, with atleast 1 letter and 1 number)");
                newPassword = Console.ReadLine();
                if (regex.IsMatch(newPassword))
                {
                    isMatched = true;
                    //Hash Pasword
                    hashedPassword = HashPassword(newPassword);

                    entry[newUsername] = hashedPassword;

                    WriteAccountData(entry);
                }
                else
                {
                    print("Incorrect Password Format.");
                }
            }
        }

        /// <summary>
        /// Writes new account data to file.
        /// </summary>
        /// <param name="fileData">Data to write to file.</param>
        public static void WriteAccountData(Dictionary<string, byte[]> fileData)
        {
            var formatter = new BinaryFormatter();

            using (var stream = File.Create("_userData.txt"))
            {
                formatter.Serialize(stream, fileData);
            }

        }


        /// <summary>
        /// Checks entered account details against saved account data.
        /// </summary>
        /// <param name="username">User entered login data.</param>
        /// <param name="password"> Hashed user entered password.</param>
        /// <returns>Boolean value representing account verification.</returns>
        public static bool VerifyLogin(string username, byte[] password)
        {
            var formatter = new BinaryFormatter();
            Dictionary<string, byte[]> deserializedList = null;

            using (var reader = File.OpenRead("_userData.txt"))
            {
                deserializedList = formatter.Deserialize(reader) as Dictionary<string, byte[]>;
            }

            //Verify password.
            //LINQ IMPLEMENTED
            if (deserializedList.Keys.Any(k => k.Contains(username)))
            {
                if (deserializedList[username].SequenceEqual(password))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Hashes input password.
        /// </summary>
        /// <param name="plainPassword">Plain text password.</param>
        /// <returns>Resulting hashed password.</returns>
        public static byte[] HashPassword(string plainPassword)
        {
            // Hash and salt the password
            byte[] data = Encoding.UTF8.GetBytes(plainPassword + "saltyDog");
            byte[] hashedPassword = SHA256.Create().ComputeHash(data);
            return hashedPassword;
        }
    }
}
