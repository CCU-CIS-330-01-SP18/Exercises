using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Week9_Serialization
{
    /// <summary>
    /// This class allows a gamer to build their own library (list of owned games).
    /// </summary>
    /// <typeparam name="T">The VideoGame type.</typeparam>
    [Serializable]
    [KnownType(typeof(Platformer))]
    [KnownType(typeof(Strategy))]
    public class GameLibrary<VideoGame> : List<VideoGame>
    {
    }
}
