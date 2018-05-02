using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ParsonsFinalProject
{
    /// <summary>
    /// A class that provides a console user interface that is inherited from the Program class.
    /// </summary>
    public class UserView : Program
    {
        /// <summary>
        /// A method that provides a console interface for the Program class
        /// </summary>
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

