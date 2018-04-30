using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Apollo11
{
    /// <summary>
    /// Creates a Planet.
    /// </summary>
    [Serializable]
    public class Planet
    {
        public string Name { get; set; }
        public int DistanceFromSun { get; set; }
        public int PlanetID { get; set; }
        public int ChanceOfDeath = RandomChanceOfDeath(1, 9);

        /// <summary>
        /// Use the Crypto Random Number Generator, to create the random chance of living when travleing.
        /// </summary>
        /// <param name="min">Lowest chance of survival.</param>
        /// <param name="max">Largest chance of Survival</param>
        /// <returns>Chance of Death</returns>
        public static int RandomChanceOfDeath(int min, int max)
        {
            RNGCryptoServiceProvider CprytoRNG = new RNGCryptoServiceProvider();
            // Generate four random bytes
            byte[] four_bytes = new byte[4];
            CprytoRNG.GetBytes(four_bytes);

            // Convert the bytes to a UInt32
            UInt32 scale = BitConverter.ToUInt32(four_bytes, 0);

            // And use that to pick a random number >= min and < max
            return (int)(min + (max - min) * (scale / (uint.MaxValue + 1.0)));
        }

        /// <summary>
        /// Calculates the distance from the user current planet to the rest of the planets in the solar system.
        /// </summary>
        /// <param name="userCurrentPlanet">User current planet.</param>
        /// <returns>Distance from current planet.</returns>
        public int GetDistanceFromCurrentPlanet(Planet userCurrentPlanet)
        {
            return Math.Abs(userCurrentPlanet.DistanceFromSun - DistanceFromSun);
        }

    }
}
