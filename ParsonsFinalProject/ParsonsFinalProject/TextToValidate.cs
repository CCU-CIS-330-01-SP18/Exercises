using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParsonsFinalProject
{
    /// <summary>
    /// A class that validates text to not have specific special characters
    /// </summary>
    public class TextToValidate
    {
        /// <summary>
        /// A method that validates strings and returns a boolean for the results of the regex.
        /// </summary>
        /// <param name="speechText"> A string that is validated.</param>
        /// <returns></returns>
        public bool ValidateText(string speechText)
        {
            bool nameWorks = Regex.IsMatch(speechText, @"^[^<>\/;~_]*$");
            if (nameWorks == false)
            {
                return false;
            }

            if (nameWorks == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
    }
}
