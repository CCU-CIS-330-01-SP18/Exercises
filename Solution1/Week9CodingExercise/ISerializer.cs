using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    interface ISerializer
    {
        void Serialize(Roster<ActionCharacter> roster);

        Roster<ActionCharacter> Deserialize();
    }
}
