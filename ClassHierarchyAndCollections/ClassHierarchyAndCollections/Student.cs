using System;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a student, who can study classes and break down emotionally.
    /// </summary>
    public class Student : Individual
    {
        public double EmotionalStability { get; set; } = 2;
        public double GPA { get; set; } = 4.0;
        public double StressLevel { get; set; } = 0;
        
        /// <summary>
        /// Initializes a new instance of the Student class.
        /// </summary>
        public Student()
        {

        }

        /// <summary>
        /// Studies coursework with the given difficulty level. Adds to stress proportional to the difficulty.
        /// </summary>
        /// <param name="difficultyLevel">The difficulty of the course.</param>
        public void Study(int difficultyLevel)
        {
            Random random = new Random();
            double grade = 4 / difficultyLevel * random.NextDouble();
            if (grade > 4)
            {
                grade = 4;
            }

            // Our GPAs are very flexible here. They can change for the better - or worse - at a moment's notice.
            GPA = (GPA + grade) / 2;
            StressLevel += 1 / EmotionalStability * difficultyLevel;
            EvaluateStress();
        }

        /// <summary>
        /// Evaluates the current stress level and triggers an emotional breakdown if the stress level has gone too far.
        /// </summary>
        private void EvaluateStress()
        {
            if (StressLevel > EmotionalStability * 50)
            {
                EmotionalBreakdown();
            }
        }

        /// <summary>
        /// Break down mentally. GPA takes a hit, but stress resets to 0.
        /// </summary>
        private void EmotionalBreakdown()
        {
            GPA = GPA * 0.75;
            StressLevel = 0;
        }
    }
}
