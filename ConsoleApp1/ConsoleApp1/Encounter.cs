using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// A scenario where the player will need to make a decision.
    /// </summary>
    class Encounter
    {
        public int EncounterID { get; set; }
        public List<Entity> Entities { get; set; }
        public List<Action> Actions { get; set; }
    }
}
