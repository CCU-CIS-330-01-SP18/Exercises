using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a team for Turf Wars, made up of <see cref="Cephalokid"/>s.
    /// </summary>
    [Serializable]
    [KnownType(typeof(Cephalokid))]
    [KnownType(typeof(Inkling))]
    [KnownType(typeof(Octoling))]
    public class Team<T> : List<T>, IEnumerable<T> where T : Cephalokid
    {
        public string Color
        {
            get; set;
        }
    }
}
