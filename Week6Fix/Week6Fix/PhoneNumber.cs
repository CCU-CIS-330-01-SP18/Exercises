using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Week6Fix
{
    public class PhoneNumber
    {
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            // Phone Number can include () with the area code, and only . - no space and space between groups of numbers.
            string phoneNumberRegexExpression = @"^(?<AreaCode>\(?\d{3}?\)?)[-.\s]?(?<FirstThreeNumbers>\d{3})[-.\s]?(?<LastFourNumbers>\d{4})$";

            return Regex.IsMatch(phoneNumber, phoneNumberRegexExpression);
        }
    }
}
