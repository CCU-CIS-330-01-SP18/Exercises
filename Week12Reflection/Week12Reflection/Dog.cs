using System;

namespace Week12Reflection
{
    /// <summary>
    /// Represents a dog. Can bark at things.
    /// </summary>
    /// <remarks>Yes, I'm uncreative. Also, I'm low on time, so you get a dog.</remarks>
    public class Dog
    {
        private int Age = 0;
        private int BarkFactor = 1;

        /// <summary>
        /// Instantiates a new Dog object.
        /// </summary>
        /// <param name="age">The age of the dog in years.</param>
        public Dog(int age)
        {
            Age = age;
        }

        /// <summary>
        /// Instantiates a new Dog object.
        /// </summary>
        /// <param name="age">The age of the dog in years.</param>
        /// <param name="barkFactor">How prone the dog is to barking.</param>
        public Dog(int age, int barkFactor)
        {
            Age = age;
            BarkFactor = barkFactor;
        }

        /// <summary>
        /// Bark at something. The amount of times the dog barks depends on the bark factor.
        /// </summary>
        private void Bark()
        {
            for (int i = 0; i <= BarkFactor; i++)
            {
                Console.WriteLine("Woof!");
            }
        }
    }
}
