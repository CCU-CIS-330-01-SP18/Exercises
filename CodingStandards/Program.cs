using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    // This is the entry point for the program.
    static DateTime Now = DateTime.Now;

    static int Main(string[] args)
    {
        return WriteMessage(Now, Console.Out);
    }

    /// <summary>
    ///  This method determines what time it is relative to 2017, and congratulates the user if 2017 has passed.
    /// </summary>
    /// <param name="currentDate">The current date, expressed as a DateTime object.</param>
    /// <param name="writer">The output stream to write the results to.</param>
    /// <returns>Returns zero.</returns>
    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        // Write a different message depending on the current date with relation to 2017.
        var resultValue = 0;
        const int messageCount = 5;
        for (int index = 0; index < messageCount; index++)
        {
            if (currentDate.Year > 2017)
            {
                // If the current date is greater than 2017, congratulate the user on a happy new year.
                writer.WriteLine("Happy New Year!");
            }
            else
            {
                writer.WriteLine("Hello From " + currentDate.Year);
            }
        }

        // Return the result value.
        return resultValue;
    }
}
