using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9_Serialization
{
    /// <summary>
    /// A class that can be serialized, representing a video game.
    /// </summary>
    [Serializable]
    class VideoGame
    {
        public string Name { get; set; }

        /// <summary>
        /// Constructs the game object.
        /// </summary>
        /// <param name="name">The name of the video game.</param>
        public VideoGame(string name)
        {
            Name = name;
        }
    }
}
