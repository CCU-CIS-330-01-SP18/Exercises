namespace Week12Reflection
{
    /// <summary>
    /// Represents a cat. Capable of scratching things.
    /// </summary>
    public class Cat
    {
        int Age = 0;
        float ClawLength = 1.0f;

        /// <summary>
        /// Instantiates a new Cat object.
        /// </summary>
        /// <param name="age">The age of the cat in years.</param>
        public Cat(int age)
        {
            Age = age;
        }

        /// <summary>
        /// Scratch at something. Results in a loss in claw length.
        /// </summary>
        private void Scratch()
        {
            if (ClawLength >= 0.1)
            {
                ClawLength -= 0.1f;
            }
        }
    }
}
