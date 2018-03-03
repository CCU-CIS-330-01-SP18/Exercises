using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Week9CodingExercise
{
    [Serializable]

    [DataContract]
    class Customer : Individual
    {
        public Customer(string name = null)
            : base(name)
        {
        }
    }
}
