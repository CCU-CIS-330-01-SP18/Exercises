using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ThreadingExercise
{
    class Program
    {
        public static void Main(string[] args)
        {
            Task<int> task = CharacterReader.CountCharacters();

            int firstNumber = 10;
            int secondNumber = 15;
            int sum = firstNumber + secondNumber;

            Console.WriteLine("Please wait while I try to do something crucial!");
            Console.WriteLine($"Let me add some numbers... {firstNumber} + {secondNumber} = {sum}");

            task.Wait();
            var characters = task.Result;
            Console.WriteLine("The number of characters is " + characters.ToString());
            Console.WriteLine("Finished");
        }
    }
}
