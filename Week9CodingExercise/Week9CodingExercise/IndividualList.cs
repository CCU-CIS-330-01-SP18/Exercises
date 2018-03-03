using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    [Serializable]

    [KnownType(typeof(Employee))]
    [KnownType(typeof(Customer))]
    public class IndividualList<T> : List<T> where T : Individual
    {
    }
}
