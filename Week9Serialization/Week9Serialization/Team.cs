using System.Collections.Generic;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a team for Turf Wars. Can contain any type of cephalokid.
    /// </summary>
    class Team : List<Cephalokid>
    {
        public InkColor Color
        {
            get; set;
        }
    }
}
