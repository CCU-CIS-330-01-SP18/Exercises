using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionCodingExercise
{
    /// <summary>
    /// A generic base class that contains two properties and a method.
    /// </summary>
    public class Animal
    {
        public string Species { get; set; }

        public int NumberOfLegs { get; set; }

        /// <summary>
        /// A generic method that provides the status of the object.
        /// </summary>
        /// <returns>A boring boolean expression.</returns>
        public bool IsAlive()
        {
            return true;
        }
    }
}
