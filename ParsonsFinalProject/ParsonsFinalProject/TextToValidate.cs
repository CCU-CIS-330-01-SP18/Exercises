using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParsonsFinalProject
{
    public class TextToValidate
    {
        internal bool ValidateText(string speechText)
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
