using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week6
{
    /// <summary>
    /// A class containing a method to determine proper phone number using regular expressions.
    /// </summary>
    public static class PhoneValidator
    {
        /// <summary>
        /// Matches only validly formatted US phone numbers. Determines if phone number is valid in format and properly provided. Takes in phone numbers as a string.
        /// </summary>
        /// <param name="phoneNumber"> The string phone number is passed to the program by the user. </param>
        /// <returns> Returns true if a phone number is valid, and returns false if phone number is provided but is invalid. </returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            // tests if a phone number is valid. This Regex expression goes by the NANP Standards (https://www.nationalnanpa.com/about_us/abt_nanp.html).
            bool phoneNumberMatch = Regex.IsMatch(phoneNumber, @"((?:\(?[2-9](?(?=1)1[02-9]|(?(?=0)0[1-9]|\d{2}))\)?\D{0,3})(?:\(?[2-9](?(?=1)1[02-9]|\d{2})\)?\D{0,3})\d{4})");

            if (phoneNumber == null)
            {
                throw new ArgumentNullException("Phone Number", "Phone number can't be null or empty.");
            }

            else if (phoneNumberMatch == true)
            {
                return true;
            }

            else if (phoneNumberMatch == false)
            {
                return false;
            }

            else
            {
                throw new InvalidOperationException("An invalid Operation Occured");
            }
        }
    }
}






