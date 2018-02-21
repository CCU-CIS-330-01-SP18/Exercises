using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validation
{
    /// <summary>
    /// Provides access to a method that uses regular expressions to validate a US-based phone number
    /// </summary>
    public class PhoneValidator
    {
        /// <summary>
        /// Takes in a phone number as a string, and performs validation against it to determine whether the number is in a valid format.
        /// </summary>
        /// <param name="number">The phone number</param>
        /// <returns>True, if the number is valid. Otherwise, returns false.</returns>
        public static bool ValidatePhoneNumber(string number)
        {
            // Test if the string is valid to use. If not, throw an exception.
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("The phone number cannot be null or empty!");
            }
            
            string expression = @"^(((\+?1)?(\.|\-| )?)?\(?\d{3}\)?)?(\.|\-| )?\d{3}(\.|\-| )?\d{4}$";
            return Regex.IsMatch(number, expression);
        }
    }
}
