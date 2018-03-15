using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;


namespace Week9Serialization
{
    /// <summary>
    ///  Instantiates a MarsupialList that has the type of object Marsupial.
    /// </summary>
    /// <typeparam name="Marsupial">The object Marsupial type.</typeparam>
    [Serializable]
    [KnownType(typeof(Quoll))]
    [KnownType(typeof(TasmanianDevil))]
    public class MarsupialList<Marsupial> : List<Marsupial>
    {
    }
}