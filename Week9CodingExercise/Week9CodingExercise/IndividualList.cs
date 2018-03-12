using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    /// <summary>
    /// Instantiates an IndividualList where the type is an Object Individual.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]

    [KnownType(typeof(Employee))]
    [KnownType(typeof(Customer))]
    public class IndividualList<T> : List<T> where T : Individual
    {
    }
}
