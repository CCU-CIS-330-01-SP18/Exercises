using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week6
{
    /// <summary>
    /// Resents a PhoneValidator Class that validates U.S. phone numbers.
    /// </summary>
    public class PhoneValidator
    {
        /// <summary>
        /// Method that validates a 7 or 10 digit U.S. phone number.
        /// </summary>
        /// <param name="phoneNumber"> String represending a single phone number string.</param>
        /// <returns>Returns a boolean representing the status of the phone number's validity.</returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            bool result;

            result = PhoneNumberIsAlpha(phoneNumber);
            if (result == true)
            {
                throw new FormatException(phoneNumber);
            }

            try
            {
                if ((phoneNumber.Length >= 10) && (phoneNumber.Length <= 14))
                {
                    result = TenDigitValidator(phoneNumber);
                    return result;
                }
                else if ((phoneNumber.Length <= 10) && (phoneNumber.Length >= 7))
                {
                    result = SevenDigitValidator(phoneNumber);
                    return result;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(phoneNumber);
                }
            }
            catch (ArgumentNullException)
            {
                if (phoneNumber == null)
                {
                    throw new ArgumentNullException(phoneNumber);
                }
                return false;
            }
        }

        /// <summary>
        /// Processes a 10 digit phoneNumber string to check its validity.
        /// </summary>
        /// <param name="phoneNumber">String represending a single phone number string.</param>
        /// <returns>Returns a boolean representing the status of the phone number's validity.</returns>
        private static bool TenDigitValidator(string phoneNumber)
        {
            var expression = new Regex(@"^\(?([0-9]{3})\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$");
            return expression.IsMatch(phoneNumber);
        }

        /// <summary>
        /// Processes a 7 digit phoneNumber string to check its validity.
        /// </summary>
        /// <param name="phoneNumber">String represending a single phone number string.</param>
        /// <returns>Returns a boolean representing the status of the phone number's validity.</returns>
        private static bool SevenDigitValidator(string phoneNumber)
        {
            var expression = new Regex(@"^\d?([0-9]{3})[-.]?([0-9]{4})$");
            return expression.IsMatch(phoneNumber);
        }

        /// <summary>
        /// Processes phoneNumber string to see if it contains letters. 
        /// </summary>
        /// <param name="phoneNumber">String represending a single phone number string.</param>
        /// <returns>Returns a boolean representing the presence of letters in the phoneNumber string.</returns>
        private static bool PhoneNumberIsAlpha(string phoneNumber)
        {
            var expression = new Regex(@"^[a-zA-z]");
            return expression.IsMatch(phoneNumber);
        }
    }
}
