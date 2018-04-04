using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12ReflectionCodingExercise
{
    /// <summary>
    /// Creates a doggo.
    /// </summary>
    public class Dog
    {
        /// <summary>
        /// Default constructor for a Dog.
        /// </summary>
        public Dog()
        {

        }

        public string Name
        {
            get; set;
        }

        public int Age
        {
            get; set;
        }

        /// <summary>
        /// Method that converts human years to dog years.
        /// </summary>
        /// <param name="age">How old the dog is.</param>
        /// <returns>The dogs age.</returns>
        private int DogToHumanYears(int age)
        {
            int calculateAge = age * 7;
            return calculateAge;
        }
    }
}
