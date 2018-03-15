using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a squidkid. Has a "freshness" score, which indicates their rank in Inkling society.
    /// </summary>
    class Inkling : Cephalokid, ISerializer
    {
        private int freshness;

        public int Freshness
        {
            get
            {
                return freshness;
            }
        }

        /// <summary>
        /// Creates a new instance of the Inkling class, with the given parameters.
        /// </summary>
        /// <param name="name">The squidkid's name.</param>
        /// <param name="age">The squidkid's age in years.</param>
        /// <param name="color">The squidkid's default ink color.</param>
        public Inkling(string name, int age, InkColor color) : base(name, age, color)
        {
            this.freshness = 0;
        }

        /// <summary>
        /// Shop for new gear, granting a bonus to freshness.
        /// </summary>
        /// <returns>The amount that the Inkling's freshness score increased by.</returns>
        public double ShopForGear()
        {
            var rand = new Random();
            int increase = rand.Next(10);
            freshness += increase;
            return increase;
        }
    }
}
