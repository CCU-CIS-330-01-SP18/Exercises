using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12Reflection
{
    public class Spaceship
    {
        public float EnginePower { get; set; }
        public bool Launched { get; set; }

        /// <summary>
        /// The defualt Spaceship contructor.
        /// </summary>
        /// <param name="enginePower">The power of the spaceship engine.</param>
        /// <param name="launched">Whether the rocket has been launched.</param>
        public Spaceship(float enginePower, bool launched)
        {
            EnginePower = enginePower;
            Launched = launched;
        }

        /// <summary>
        /// Enables the rocket to launch.
        /// </summary>
        /// <returns>A message to whether the rocket can be launched.</returns>
        public string LaunchRocket()
        {
            if (!Launched)
            {
                return "Rocket Launching in 3.2.1....";
            }
            else
            {
                return "Rocket has already launched";
            }
        }

    }
}
