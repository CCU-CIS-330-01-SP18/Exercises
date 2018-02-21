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
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            { 
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            string expression = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            
            return Regex.IsMatch(phoneNumber, expression);
        }
    }
}
    


