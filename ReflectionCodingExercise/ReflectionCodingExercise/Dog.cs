using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionCodingExercise
{
    /// <summary>
    /// A generic class that contains two properties and one method and inherits from the Animal class.
    /// </summary>
    public class Dog 
    {
        public string Name { get; set; }

        public int Age { get; set; }

        /// <summary>
        /// A generic method that provides and returns the sound of a dog.
        /// </summary>
        /// <returns>The sound a dog makes.</returns>
        public string Bark()
        {
            var bark = ("Ruff! Ruff!");
            return bark;
        }
    }
}

