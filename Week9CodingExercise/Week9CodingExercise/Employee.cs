using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    [Serializable]

    [DataContract]
    public class Employee : Individual
    {
        public Employee(string name = null)
            : base(name)
        {
        }
    }
}
