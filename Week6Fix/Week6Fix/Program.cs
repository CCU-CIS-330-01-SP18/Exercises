using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Week6Fix
{
    class Program
    {
        static void Main(string[] args)
        {

            ValidatePhoneNumber("say 25 miles more");
        }

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            Console.WriteLine(Regex.Match(phoneNumber, @"(?<=say\s)\d+").Success);
            System.Threading.Thread.Sleep(5000);

            return false;
        }
    }
}
