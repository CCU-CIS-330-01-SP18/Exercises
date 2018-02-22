using System;
using System.Text.RegularExpressions;

namespace PhoneValidator
{
    /// <summary>
    /// Validates US phone numbers with regex expressions.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validate the given phone number with regex.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>Whether or not the given phone number is valid.</returns>
        public static bool Validate(string phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException("phoneNumber", "Phone number cannot be null");
            }
            else if (phoneNumber == String.Empty)
            {
                throw new ArgumentException("Phone number cannot be empty", "phoneNumber");
            }

            /*
             * Notes on the following regex:
             * CountryCode only matches 1 because it is the US code. This class only validates US phone numbers.
             * Area codes in the US cannot start with a 0 or 1, which is why I match [2-9] first, and then any other digit twice.
             * The Central Office Code, too, cannot start with a 0 or 1, so I used the same idea as with the area code.
             * There is also a special clause for the numbers 211 through 911. They have various functions; Google N11 codes for details.
             * I certainly hope you know what 911 is for.
             */
            return new Regex(@"^(?<CountryCode>\+?1[-\.\s]?)?" +
                @"(?<AreaCode>[\(\[]?[2-9]\d{2}[\)\]]?[-\.\s]?)?" +
                @"(?<CentralOfficeCode>([2-9]\d{2})[-\.\s]?" +
                @"(\d{4}))$|^(?<N11>[2-9]-?1-?1)$").IsMatch(phoneNumber);
        }
    }
}
