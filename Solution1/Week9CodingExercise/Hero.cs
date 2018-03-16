using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Week9CodingExercise
{
    /// <summary>
    /// Represents a Hero character.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Hero : ActionCharacter
    {
        public string SuperPower { get; set; }

        /// <summary>
        /// Constructor for Hero
        /// </summary>
        /// <param name="name">Name of the Hero</param>
        public Hero(string name = null) : base(name)
        { }
    }
}
