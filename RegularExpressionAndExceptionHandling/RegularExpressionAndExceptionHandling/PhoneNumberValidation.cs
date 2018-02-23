using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace RegularExpressionAndExceptionHandling
{
    /// <summary>
    /// This class is for validating various forms of phone number formats.
    /// </summary>
    public class PhoneNumberValidation
    {
        /// <summary>
        /// Takes a phone number and confirms that it is valid while also not being null or empty.
        /// </summary>
        /// <param name="phoneNumber">A phone number to be passed in for validation</param>
        /// <returns>If valid will return true. If invalid, null, or empty, returns false.</returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            string phoneNumberRegex = @"^(?<LeadingOne>\+?1)?(\-| |\.)?(?<AreaCode>\(?\d{3}\)?)?(\-| |\.)?(?<FirstSet>\d{3})(\-| |\.)?(?<SecondSet>\d{4})$";

            if (phoneNumber == "" | phoneNumber == null)
            {
                throw new ArgumentNullException(phoneNumber, "Provided number is null or empty.");
            }

            return Regex.IsMatch(phoneNumber, phoneNumberRegex);
        }
    }
}