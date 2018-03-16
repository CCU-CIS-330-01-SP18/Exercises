using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Assignment
{
    /// <summary>
    /// A class which can hold a collection of People
    /// </summary>
    /// <typeparam name="T"></typeparam>
    
    // Required for Binary serialization.
    [Serializable]

    // Required for DataContract serialization.
    [KnownType(typeof(Male))]
    [KnownType(typeof(Female))]

    public class PersonList<T>: List<T> where T: Person
    {
    }
}
