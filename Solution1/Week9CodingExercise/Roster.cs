using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Week9CodingExercise
{
    /// <summary>
    /// Class that allows Characters collection in a Roster.
    /// </summary>
    [Serializable]
    [KnownType(typeof(Hero))]
    [KnownType(typeof(Villan))]
    class Roster<ActionCharacter> : List<ActionCharacter>
    {
    }
}
