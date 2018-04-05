using System;

namespace Week12Reflection
{
    /// <summary>
    /// Represents a dog. Can bark at things.
    /// </summary>
    /// <remarks>Yes, I'm uncreative. Also, I'm low on time, so you get a dog.</remarks>
    public class Dog
    {
        // These fields are set to private to demonstrate how reflection can bypass access modifiers.
        private int age = 0;
        private int barkFactor = 1;

        /// <summary>
        /// Instantiates a new Dog object.
        /// </summary>
        /// <param name="age">The age of the dog in years.</param>
        public Dog(int age)
        {
            this.age = age;
        }

        /// <summary>
        /// Instantiates a new Dog object.
        /// </summary>
        /// <param name="age">The age of the dog in years.</param>
        /// <param name="barkFactor">How prone the dog is to barking.</param>
        public Dog(int age, int barkFactor)
        {
            this.age = age;
            this.barkFactor = barkFactor;
        }

        /// <summary>
        /// Bark at something. The amount of times the dog barks depends on the bark factor.
        /// </summary>
        /// <remarks>This method is private to demonstrate reflection's ability to work around access modifiers.</remarks>
        private void Bark()
        {
            for (int i = 0; i <= barkFactor; i++)
            {
                Console.WriteLine("Woof!");
            }

            // Barking begets more barking.
            barkFactor++;
        }
    }
}
