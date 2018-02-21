using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week6
{
    /// <summary>
    ///     
    /// </summary>
    public class PhoneValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            bool result;

            result = PhoneNumberIsNotANumber(phoneNumber);
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
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private static bool TenDigitValidator(string phoneNumber)
        {
            var expression = new Regex(@"^\(?([0-9]{3})\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$");
            return expression.IsMatch(phoneNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private static bool SevenDigitValidator(string phoneNumber)
        {
            var expression = new Regex(@"^\d?([0-9]{3})[-.]?([0-9]{4})$");
            return expression.IsMatch(phoneNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private static bool PhoneNumberIsNotANumber(string phoneNumber)
        {
            var expression = new Regex(@"^[a-zA-z]");
            return expression.IsMatch(phoneNumber);
        }
    }
}
