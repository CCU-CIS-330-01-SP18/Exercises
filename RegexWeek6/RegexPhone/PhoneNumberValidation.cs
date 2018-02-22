using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexPhone
{
    /// <summary>
    /// This is the class that holds a method which checks to see if a given phone number is valid.
    /// </summary>
    public class PhoneNumberValidation
    {
        /// <summary>
        /// Ensures that a given phone number is valid according to regex statement.
        /// </summary>
        /// <param name="phoneNumber">
        /// A string which is supposed to be a phone number.
        /// </param>
        /// <returns>
        /// This method will return true if the given string is in fact a phone number, and false if it is not.
        /// </returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            bool isPhoneNumber = Regex.IsMatch(phoneNumber, @"^([(]?\d{3}[)]?)?[ -.]?\d{3}[ -.]?\d{4}$");

            if (isPhoneNumber)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
                throw new ArgumentNullException(nameof(phoneNumber));
            }
            else
            {
                return false;
                throw new ArgumentOutOfRangeException(nameof(phoneNumber));
            }
        }
    }
}
