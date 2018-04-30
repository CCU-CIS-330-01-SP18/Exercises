using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;

namespace Apollo11
{
    /// <summary>
    /// The headquarters for the app. This is where the app is ran from.
    /// </summary>
    class SpaceHeadquarters
    {
        /// <summary>
        /// This is the method which starts the console application.
        /// </summary>
        /// <param name="args">The arguments which the Main method can utilize.</param>
        static void Main(string[] args)
        {
            var list = SerializeAndDeserialize.GeneratePlanetSerializeAndDeserialize();
            BeginSpaceTravel(list);
            
        }
         
        /// <summary>
        /// This is the first stage to travel with us entering your email address.
        /// </summary>
        /// <param name="list">List of planets to travel to.</param>
        public static void BeginSpaceTravel(PlanetList<Planet> list)
        {
            Console.WriteLine("Welcome to Apollo 11 Space Travel.");
            Console.WriteLine("Enter your email to begin");
            string email = Console.ReadLine();

            if (RegexValidator.EmailValidatorCheck(email))
            {
                Console.WriteLine("You are now ready for space travel");

                //Sets the current planet - Earth
                Planet currentPlanet = DisplayPlanets.DisplayCurrentPlanet(list, 3);

                //Prints the Planets
                DisplayPlanets.DispalyPlanetList(list, currentPlanet);

                Console.WriteLine();
                Travel(list);
            }
        }

        /// <summary>
        /// Next step, Space travel here we send you on your way to your desired planet.
        /// </summary>
        /// <param name="list">List of planets to travel to.</param>
        public static void Travel(PlanetList<Planet> list)
        {
            Console.WriteLine("Enter the corresponding number to travel to that planet.");
            string planetChoice = Console.ReadLine();
            Console.WriteLine();

            if (RegexValidator.NumberValidatorCheck(Convert.ToInt32(planetChoice)));
            {
                // Readline is a string converts planetChoice to an int
                int choice = Convert.ToInt32(planetChoice);
               
                // Displays the chance of traveling dangerous space travel.
                Console.WriteLine("Your chance of survival is... " + DisplayPlanets.DisplayChanceOfDeath(list, choice) * 10 + "%");

                // Two second travel speed.
                Console.WriteLine("You are Currently Traveling...");
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);

                // Displays the planet you landed on.
                DisplayPlanets.DisplayCurrentPlanet(list, choice);
                Console.WriteLine("Press Any Button to Quit");
                Console.ReadLine();
            }
            
        }

    }
}
