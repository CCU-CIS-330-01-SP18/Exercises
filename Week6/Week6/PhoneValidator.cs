using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week6
{
    public class PhoneValidator
    {
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            bool result;

            if (phoneNumber == null)
            {
                throw new ArgumentNullException(phoneNumber);
            }

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

        private static bool TenDigitValidator(string phoneNumber)
        {
            var expression = new Regex(@"^\(?([0-9]{3})\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$");
            return expression.IsMatch(phoneNumber);
        }

        private static bool SevenDigitValidator(string phoneNumber)
        {
            var expression = new Regex(@"^\d?([0-9]{3})[-.]?([0-9]{4})$");
            return expression.IsMatch(phoneNumber);
        }
    }
}
