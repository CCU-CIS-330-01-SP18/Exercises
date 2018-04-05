using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12Reflection
{
    public class Astronaut
    {
        public int Age { get; set; }
        public string Mission { get; set; }

        /// <summary>
        /// The default Astronaut constructor.
        /// </summary>
        /// <param name="age">The age of the Astronuat.</param>
        /// <param name="mission">The name of the mission.</param>
        public Astronaut(int age, string mission)
        {
            Age = age;
            Mission = mission;
        }

        /// <summary>
        /// Check if you have Mission Clearance Access.
        /// </summary>
        /// <returns>If you are an astronaut you have access, therefore true.</returns>
        public bool MissionComfirmed()
        {
            return true;
        }
    }
}
