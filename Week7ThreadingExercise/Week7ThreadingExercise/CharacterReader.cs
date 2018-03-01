using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week7ThreadingExercise
{
    /// <summary>
    /// A class that reads characters in a text file.
    /// </summary>
    public class CharacterReader
    {
        /// <summary>
        /// Reads the amount of characters in a text file.
        /// </summary>
        /// <returns>The amount of characters in the file.</returns>
        public static async Task<int> CountCharacters()
        {
            /* NOTE: I have included a text file already named Data.txt, which you can look at
               For yourselves in my Solution Explorer. This file is located in Week7ThreadingExercise\bin\Debug.
            */
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
