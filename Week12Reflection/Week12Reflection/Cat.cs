namespace Week12Reflection
{
    /// <summary>
    /// Represents a cat. Capable of scratching things.
    /// </summary>
    public class Cat
    {
        int age = 0;
        float clawLength = 1.0f;

        /// <summary>
        /// Instantiates a new Cat object.
        /// </summary>
        /// <param name="age">The age of the cat in years.</param>
        public Cat(int age)
        {
            this.age = age;
        }

        /// <summary>
        /// Scratch at something. Results in a loss in claw length.
        /// </summary>
        /// <remarks>This method is private to demonstrate reflection's ability to work around access modifiers.</remarks>
        private void Scratch()
        {
            if (clawLength >= 0.1)
            {
                clawLength -= 0.1f;
            }
        }
    }
}
