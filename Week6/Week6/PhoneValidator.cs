using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week6
{
    public static class PhoneValidator
    {
        //string phoneValidator = @"([0-9]{3})[\s\.\-]([0-9]{3})[\s\.\-]([0-9]{4})|([0-9]{3})[\s\.\-]([0-9]{4})";
        //var phoneRegex = new Regex(@"([0-9]{3})[\s\.\-]([0-9]{3})[\s\.\-]([0-9]{4})|([0-9]{3})[\s\.\-]([0-9]{4})");
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            //var regex = new Regex(@"^([0-9]{3})[\s\.\-]([0-9]{3})[\s\.\-]([0-9]{4})|^([0-9]{3})[\s\.\-]([0-9]{4})");
            var regex = new Regex(@"^(\(?\d{3}\)?)[\s\.\-]?(\d{0,3})[\s\.\-]?(\d{0,4})$|^(\d{0,3})[\s\.\-]?(\d{0,4})$");
            Match match = regex.Match(phoneNumber);

            if (match.Success)
            {
                return true;
            }
            else if (phoneNumber == null)
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
