using System;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a student, who can study classes and break down emotionally.
    /// </summary>
    public class Student : Individual
    {
        private double stressLevel = 0;

        public double EmotionalStability { get; set; } = 2;
        public double GPA { get; set; } = 4.0;
        public double StressLevel
        {
            get
            {
                return stressLevel;
            }
        }
        
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

            // Our GPAs are very flexible here. They can change for the better - or worse - at a moment's notice.
            GPA = (GPA + grade) / 2;
            if (GPA > 4)
            {
                GPA = 4;
            }
            stressLevel += 1 / EmotionalStability * difficultyLevel;
            EvaluateStress();
        }

        /// <summary>
        /// Takes some time to relax, causing a random amount of stress to melt away.
        /// </summary>
        public void Destress()
        {
            Random random = new Random();
            double destressAmount = random.NextDouble() * EmotionalStability * 50;
            if (destressAmount == 0)
            {
                // You WILL relax, even if we have to force-feed you sleeping pills to make you do it. Destressing never fails.
                destressAmount = 0.1;
            }
            stressLevel -= destressAmount;
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
            else if (StressLevel < 0)
            {
                stressLevel = 0;
            }
        }

        /// <summary>
        /// Break down mentally. GPA takes a hit, but stress resets to 0 as the student forgets everything they know.
        /// </summary>
        private void EmotionalBreakdown()
        {
            GPA = GPA * 0.75;
            stressLevel = 0;
        }
    }
}
