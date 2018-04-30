using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo11
{
    class DisplayPlanets
    {
        /// <summary>
        /// Displays the list of planets.
        /// </summary>
        /// <param name="planetList">List of Planets.</param>
        /// <param name="userCurrentPlanet">Current planet the user is on.</param>
        public static void DispalyPlanetList(PlanetList<Planet> planetList, Planet userCurrentPlanet)
        {
            Console.WriteLine();
            Console.WriteLine();

            var PlanetLinqSort = planetList.AsParallel().OrderBy(x => x.DistanceFromSun).ToList();
            
            foreach (var item in PlanetLinqSort)
            {
                if (item.PlanetID != userCurrentPlanet.PlanetID)
                {
                    int distanceFromCurrentPlanet = Math.Abs(userCurrentPlanet.DistanceFromSun - item.DistanceFromSun);
                    string planetName = item.Name;
                    int planetID = item.PlanetID;
                    Console.WriteLine(planetID + ". " + planetName + ", Distance from current planet: " + distanceFromCurrentPlanet);
                }
            } 
        }

        /// <summary>
        /// Displays which Planet the user is currently on.
        /// </summary>
        /// <param name="planetList">List of Planets.</param>
        /// <param name="userPlanetID">ID to the planet the user is on.</param>
        /// <returns>The current planet the user is on.</returns>
        public static Planet DisplayCurrentPlanet(PlanetList<Planet> planetList, int userPlanetID)
        {
            Planet currentPlanet = null;

            var PlanetLinqFind = planetList.Where(x => x.PlanetID == userPlanetID).ToList();

            foreach (var planet in PlanetLinqFind)
            {
                currentPlanet = planet;
                string currentPlanetName = planet.Name;
                Console.WriteLine("You are currently on: " + currentPlanetName);
                
                Console.WriteLine();
            }

            return currentPlanet;
        }

        /// <summary>
        /// Finds the current chance of death, based on what planet the user is traveling.
        /// </summary>
        /// <param name="planetList">List of Planets</param>
        /// <param name="userPlanetID">ID to the current planet the user is on.</param>
        /// <returns>The chance the user has of death.</returns>
        public static int DisplayChanceOfDeath(PlanetList<Planet> planetList, int userPlanetID)
        {
            int chanceOfDeath = 0;

            var PlanetLinqFind = planetList.Where(x => x.PlanetID == userPlanetID).ToList();

            foreach (var planet in PlanetLinqFind)
            {
                chanceOfDeath = planet.ChanceOfDeath;
            }

            return chanceOfDeath;
            
        }
    }
}
