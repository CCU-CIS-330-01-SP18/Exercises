using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ParsonsFinalProject
{
    public class UserView : Program
    {
        public static void UserInterface()
        {

            Console.WriteLine("Write out the statement for audio conversion:");
            var speechText = Console.ReadLine();

            //var result = TextToValidate.ValidateText(speechText);
            var textValidator = new TextToValidate();
            bool valid = textValidator.ValidateText(speechText);
            if (valid == true)
            {
                APICallAsync(speechText);
            }
            else
            {
                Console.WriteLine("No Special Characters Allowed!");
                UserInterface();
            }

        }
        
    }
}

