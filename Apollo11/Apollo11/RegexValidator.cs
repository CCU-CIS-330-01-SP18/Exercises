using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Apollo11
{
    /// <summary>
    /// Handles all the input with Regex.
    /// </summary>
    public class RegexValidator
    {
        /// <summary>
        /// Email Address check.
        /// </summary>
        /// <param name="emailAddress">Email Address Passed in.</param>
        /// <returns>True is it a valid email address</returns>
        public static bool EmailValidator(string emailAddress)
        {
            bool isEmailValid = Regex.IsMatch(emailAddress, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$");

            if (isEmailValid)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Handles the errors for email address regex.
        /// </summary>
        /// <param name="email">Email that is passed in.</param>
        /// <returns>True or False based on the results.</returns>
        public static bool EmailValidatorCheck(string email)
        {
            try
            {
                bool emailSuccess = RegexValidator.EmailValidator(email);
                if (emailSuccess)
                {
                    return true;
                }
            }
            catch (ArgumentNullException error)
            {
                Console.WriteLine($"{error.GetType().Name}: You did not enter an Email Address.");
                return false;
            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine($"{error.GetType().Name}: You entered an invalid email. ");
                return false;
            }

            return false;
        }

        /// <summary>
        /// Number check.
        /// </summary>
        /// <param name="numberEntry">Number Entry Passed in.</param>
        /// <returns>True is it a valid number entry</returns>
        public static bool NumberEntryValidator(int numberEntry)
        {
            bool isNumberEntryValid = Regex.IsMatch(numberEntry.ToString(), @"^\d$");

            if (isNumberEntryValid)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(numberEntry.ToString())) 
            {
                throw new ArgumentNullException();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Handles the errors for number entry regex.
        /// </summary>
        /// <param name="numberEntry">number passed in</param>
        /// <returns>True or False passed on try/catch </returns>
        public static bool NumberValidatorCheck(int numberEntry)
        {
            try
            {
                bool entrySuccess = RegexValidator.NumberEntryValidator(numberEntry);
                if (entrySuccess)
                {
                    return true;
                }
            }
            catch (ArgumentNullException error)
            {
                Console.WriteLine($"{error.GetType().Name}: You did not enter an Planet.");
                return false;
            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine($"{error.GetType().Name}: You entered an invalid Planet. ");
                return false;
            }

            return false;
        }
    }
}


