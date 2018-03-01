using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week7ThreadingExercise
{
    public class CharacterReader
    {
        public static async Task<int> CountCharacters()
        {
            string fileName = "Data.txt";
            Console.WriteLine("Entering CountCharacters()");
            int count = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                string content = await reader.ReadToEndAsync();
                count = content.Length;
                Thread.Sleep(5000);
            }
            Console.WriteLine("Exiting CountCharacters()");
            return count;
        }
    }
}
