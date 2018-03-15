using System;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a squidkid. Has a "freshness" score, which indicates their rank in Inkling society.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Inkling : Cephalokid
    {
        [DataMember]
        public int Freshness
        {
            get; set;
        }

        /// <summary>
        /// Creates a new instance of the Inkling class, with the given parameters.
        /// </summary>
        /// <param name="name">The squidkid's name.</param>
        /// <param name="color">The squidkid's default ink color.</param>
        public Inkling(string name, string color) : base(name, color)
        {
            Freshness = 0;
        }

        /// <summary>
        /// Shop for new gear, granting a bonus to freshness.
        /// </summary>
        /// <returns>The amount that the Inkling's freshness score increased by.</returns>
        public double ShopForGear()
        {
            var rand = new Random();
            int increase = rand.Next(10);
            Freshness += increase;
            return increase;
        }
    }
}
