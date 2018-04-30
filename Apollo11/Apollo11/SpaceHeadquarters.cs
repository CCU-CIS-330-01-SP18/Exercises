using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo11
{
    class SpaceHeadquarters
    {
        static void Main(string[] args)
        {
            BeginSpaceTravel();
        }


        public static void BeginSpaceTravel()
        {
            Console.WriteLine("Welcome to Apollo 11 Space Travel.");
            Console.WriteLine("Enter your email to begin");
            string email = Console.ReadLine();

            try
            {
                bool emailSuccess = RegexValidator.EmailValidator(email);
                if (emailSuccess)
                {
                    Console.WriteLine("Success");
                    Console.ReadLine();
                }
            }
            catch(ArgumentNullException error)
            {
                Console.WriteLine($"{error.GetType().Name}: You did not enter an Email Address.");
            }
            catch(ArgumentOutOfRangeException error)
            {
                Console.WriteLine($"{error.GetType().Name}: You entered an invalid email. ");
            }
        }
    }
}
