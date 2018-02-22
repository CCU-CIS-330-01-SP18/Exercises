using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexAndExceptionHandling
{
    /// <summary>
    /// An instance of a United States cellular device.
    /// </summary>
    public class UsPhone
    {
        public string ValidNumberRegex = @"^(\()?\d{3}(?(1)\))(?(1)[ \.-]?|(?(?!\d{7})[ \.-]))\d{3}([ \.-])?\d{4}$";

        /// <summary>
        /// Checks if a phone number is written in a valid format.
        /// </summary>
        /// <param name="phoneNumber">The phone number to verify.</param>
        /// <returns>True if the phone number is in a valid format, false if it is not.</returns>
        public bool IsValidNumber(string phoneNumber)
        {
            if (phoneNumber == null | phoneNumber == "")
            {
                throw new ArgumentNullException(phoneNumber, "Phone number is null or empty.");
            }

            return Regex.IsMatch(phoneNumber, ValidNumberRegex) ? true : false;
        }
    }
}
