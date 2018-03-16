using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Week9Assignment
{
    // Required for Binary serialization.
    [Serializable]
    // Required for DataContract serialization.
    [DataContract]

    /// <summary>
    /// This is a serializable class which contains a few properties for a Person.
    /// </summary>

    public class Person
    {
        public Person(string name = null)
        {
            string Name = name;
            Console.WriteLine("Hello "+ Name);
        }

        public string Name { get; set; }
        public float Age { get; set; }
    }
}
