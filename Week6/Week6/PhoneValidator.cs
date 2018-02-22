using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Week6
{
    /// <summary>
    /// Provides validation for US Phone Numbers.
    /// </summary>
    public class PhoneValidator
    {
        /// <summary>
        /// Takes in a phone number as a string, and checks to see if it is a valid phone number using Regex.
        /// </summary>
        /// <param name="phoneNumber">The phone number that will be validated.</param>
        /// <returns>True, if the number is valid. Otherwise, returns false.</returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null | phoneNumber == "")
            {
                throw new ArgumentNullException(phoneNumber, "Phone number is null or empty.");
            }

            // Phone Number can include () with the area code, and only . - no space and space between groups of numbers.
            string phoneNumberRegexExpression = @"^(?<AreaCode>\(?\d{3}?\)?)?[-.\s]?(?<FirstThreeNumbers>\d{3})[-.\s]?(?<LastFourNumbers>\d{4})$";

            return Regex.IsMatch(phoneNumber, phoneNumberRegexExpression);
        }
        
    }
}
