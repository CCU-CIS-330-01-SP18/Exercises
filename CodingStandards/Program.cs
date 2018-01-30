using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Program writes a message contingent on the current year.
/// </summary>
class Program
{
    /// <summary>
    /// This is the entry point for the program.
    /// </summary>
    /// <param name="args"> Takes a string argument.</param>
    /// <returns> Returns the New Year message.</returns>
    static DateTime dateNow = DateTime.Now;
    static int Main(string[] args)
    {
        return WriteMessage(dateNow, Console.Out);
    }
    /// <summary>
    /// Writes a message dependent on the current year.
    /// </summary>
    /// <param name="currentDate">This is a DateTime object taken from system date time.</param>
    /// <param name="writer">This is a TextWriter object that will be written to.</param>
    /// <returns>Returns 0</returns>
    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        var resultValue = 0;
        const int messageCount = 5;
        for (int myIndex = 0; myIndex < messageCount; myIndex++)
        {
            // Determines whether the current year is greater than 2017 and writes a message for the user. 
            if (currentDate.Year > 2017)
            {
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
