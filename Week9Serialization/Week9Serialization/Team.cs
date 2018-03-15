using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a team for Turf Wars.
    /// </summary>
    [Serializable]
    [KnownType(typeof(Inkling))]
    [KnownType(typeof(Octoling))]
    class Team<T> : List<T> where T : Cephalokid
    {
        public InkColor Color
        {
            get; set;
        }
    }
}
