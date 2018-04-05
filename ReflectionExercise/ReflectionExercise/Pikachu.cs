using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExercise
{
    /// <summary>
    /// A small electric mouse that has attacks and can level up.
    /// </summary>
    public class Pikachu
    {
        public int Level { get; set; }
        public string[] Attacks { get; set; }

        /// <summary>
        /// A constructor method for Pikachu.
        /// </summary>
        /// <param name="level">The level of the Pikachu.</param>
        /// <param name="attacks">The names of the attacks Pikachu can use.</param>
        public Pikachu(int level, string[] attacks)
        {
            Level = level;
            Attacks = attacks;
        }

        /// <summary>
        /// Increase the level of the Pikachu by one.
        /// </summary>
        /// <returns>The new level of the Pikachu.</returns>
        public int LevelUp()
        {
            Level++;
            return Level;
        }
    }
}
