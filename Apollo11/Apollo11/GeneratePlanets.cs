using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo11
{
    /// <summary>
    /// Planet Generator - Adds the planets to the List PlanetList
    /// </summary>
    public class GeneratePlanets
    {
        /// <summary>
        /// Adds all the planets in the solar system to the list
        /// </summary>
        /// <returns>Planet List</returns>
        public static PlanetList<Planet> GenerateThePlanets()
        {
            // Creates the List of Planets
            var list = new PlanetList<Planet>();
            list.Add(new Planet() { Name = "Mercury", DistanceFromSun = 58, PlanetID = 1 });
            list.Add(new Planet() { Name = "Venus", DistanceFromSun = 108, PlanetID = 2 });
            list.Add(new Planet() { Name = "Earth", DistanceFromSun = 150, PlanetID = 3 });
            list.Add(new Planet() { Name = "Mars", DistanceFromSun = 228, PlanetID = 4 });
            list.Add(new Planet() { Name = "Jupiter", DistanceFromSun = 778, PlanetID = 5 });
            list.Add(new Planet() { Name = "Saturn", DistanceFromSun = 1427, PlanetID = 6 });
            list.Add(new Planet() { Name = "Urans", DistanceFromSun = 2871, PlanetID = 7 });
            list.Add(new Planet() { Name = "Neptune", DistanceFromSun = 4497, PlanetID = 8 });

            return list;
        }
    }
}
