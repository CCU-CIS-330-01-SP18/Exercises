using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12Reflection
{
    /// <summary>
    /// A class representing the Castle Anthrax, for use in reflection.
    /// </summary>
    public class CastleAnthrax
    {
        public bool IsHoly { get; set; }

        public bool IsNecessaryForPlot { get; set; }

        /// <summary>
        /// A simple method to return the number of maidens inside Castle Anthrax.
        /// </summary>
        /// <returns>"Eight score," written numerically.</returns>
        public int GetNumberOfMembers()
        {
            int score = 20;
            int numberOfScores = 8;

            return score * numberOfScores;
        }
    }
}
