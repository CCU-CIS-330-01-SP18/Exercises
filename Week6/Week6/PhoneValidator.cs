using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week6
{
    /// <summary>
    /// A class for validating phone numbers.
    /// </summary>
    public static class PhoneValidator
    {
        /// <summary>
        /// A method that takes a string and checks if its a valid phone number.
        /// </summary>
        /// <param name="phoneNumber">A string that is passed in and checked to see if it is a valid phone number.</param>
        /// <returns>A boolean value, true if the passed in string and the regular expression match, and false if it doesn't.</returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            var regex = new Regex(@"^(\(?\d{3}\)?)[\s\.\-]?(\d{0,3})[\s\.\-]?(\d{0,4})$|^(\d{0,3})[\s\.\-]?(\d{0,4})$");
            var match = regex.Match(phoneNumber);

            if (match.Success)
            {
                return true;
            }
            else if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }
            else
            {
                return false;
            }
        }
    }
}
