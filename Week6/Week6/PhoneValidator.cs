using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Week6
{
    public class PhoneValidator
    {
        

        
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if(phoneNumber == null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            Console.WriteLine(Regex.Match("say 25 miles more", @"(?<=say\s)\d+"));

            return false;
        }
        
    }
}
