using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ThreadingExercise
{
    /// <summary>
    /// Main entry point of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This shows the interactive way of how the task I created works which you can find in <see cref="CharacterReader"/>
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Starts the CountCharacters method from the CharacterReader Class.
            Task<int> task = CharacterReader.CountCharacters();

            int firstNumber = 10;
            int secondNumber = 15;
            int sum = firstNumber + secondNumber;

            Console.WriteLine("Please wait while I try to do something crucial!");
            Console.WriteLine($"Let me add some numbers... {firstNumber} + {secondNumber} = {sum}");

            // Waits for the task to complete and then displays the results.
            task.Wait();
            var characters = task.Result;
            Console.WriteLine($"The number of characters is {characters}");
            Console.WriteLine("Finished");
        }
    }
}
