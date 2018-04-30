using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Requires that the user be the admin.
    /// </summary>
    public class AdministrationLogin
    {
        /// <summary>
        /// Checks to see if the username and password provided match the admin's username and password.
        /// </summary>
        public static void AdminLogin()
        {
            string hashedUsername = HashAdminData("Awesome Anderson");
            string hashedPass = HashAdminData("Dylan is hilarious");

            while (true)
            {
                bool isCorrectUsername = CheckAdministration(hashedUsername, "Please enter your admin username.");
                bool isCorrectPassword = CheckAdministration(hashedPass, "Please enter your admin password.");

                if (isCorrectPassword && isCorrectUsername)
                {
                    Console.WriteLine();
                    Console.WriteLine("Greetings admin.");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect username or password. Try not to be such a failure next time.");
                }
            }

        }

        /// <summary>
        /// Hash the admin data.
        /// </summary>
        /// <param name="password">The data to be encrypted.</param>
        /// <returns>The encrypted data in string format.</returns>
        public static string HashAdminData(string data)
        {
            string hashedPass = Encryption.HashItUp(data);
            return hashedPass;
        }

        /// <summary>
        /// Checks to see if the hashed admin data matches the hashed provided values.
        /// </summary>
        /// <param name="adminData">The correct admin data which the provided data must match</param>
        /// <param name="prompt">The prompt to enter a certain type of data.</param>
        /// <returns>True or false depending on if the data provided matched the admin data.</returns>
        public static bool CheckAdministration(string adminData, string prompt)
        {
            Console.WriteLine();
            Console.WriteLine(prompt);
            string pass = Console.ReadLine();

            string typedPass = Encryption.HashItUp(pass);
            if (object.Equals(typedPass, adminData))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
