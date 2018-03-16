using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    /// <summary>
    /// Represents a Villan character.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Villan : ActionCharacter
    {
        public string SuperPower { get; set; }

        /// <summary>
        /// Constructor for Hero
        /// </summary>
        /// <param name="name">Name of the Hero</param>
        public Villan(string name = null) : base(name)
        { }
    }
}
