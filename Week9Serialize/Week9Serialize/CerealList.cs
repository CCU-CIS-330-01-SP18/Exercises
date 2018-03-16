using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    /// <summary>
    /// A list of cereals.
    /// </summary>
    [Serializable]
    [KnownType(typeof(Cereal))]
    [KnownType(typeof(CocoPuffs))]
    [KnownType(typeof(FruityBites))]
    [KnownType(typeof(MiniWheats))]
    public class CerealList : List<Cereal>
    {
    }
}
