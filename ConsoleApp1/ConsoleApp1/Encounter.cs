using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// A scenario where the player will need to make a decision.
    /// </summary>
    public class Encounter
    {
        /// <summary>
        /// ID for the Encounter
        /// </summary>
        public int EncounterID { get; set; }
        /// <summary>
        /// Entities contained within the encounter.
        /// </summary>
        public List<Entity> Entities { get; set; }
        /// <summary>
        /// Available Actions that can be taken by the player in the Encounter.
        /// </summary>
        public List<Action> Actions { get; set; }
        public Encounter(int encounterID)
        {
            this.EncounterID = encounterID;
        }
        public Encounter(int encounterID, List<Entity> entities)
        {
            this.EncounterID = encounterID;
            this.Entities = entities;
        }
    }
}
