using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9_Serialization
{
    /// <summary>
    /// Represents a Platformer video game.
    /// </summary>
    [Serializable]
    [DataContract]
    class Platformer : VideoGame
    {
        /// <summary>
        /// Constructs the object in line with the parent object.
        /// </summary>
        /// <param name="name">The name of the video game.</param>
        public Platformer(string name = null) : base(name)
        { }
    }
}
