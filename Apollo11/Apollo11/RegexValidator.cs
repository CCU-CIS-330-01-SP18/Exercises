using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Apollo11
{
    public class RegexValidator
    {
        public static bool EmailValidator(string emailAddress)
        {
            bool isEmailValid = Regex.IsMatch(emailAddress, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$");

            if (isEmailValid)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }




    }
}


