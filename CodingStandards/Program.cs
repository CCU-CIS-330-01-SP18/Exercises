using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>This program is responsible for writing a message based on the current year.</summary>
class Program
{
    static DateTime now = DateTime.Now;

    /// <summary>This is the entry point for the program.</summary>
    /// <param name="args">Program arguments.</param>
    /// <returns>The New Year status message.</returns>
    static int Main(string[] args)
    {
        return WriteMessage(now, Console.Out);
    }

    /// <summary>Writes the year's greeting to a TextWriter, and returns a value.</summary>
    /// <param name="currentDate">The current date's DateTime object.</param>
    /// <param name="writer">The TextWriter object that will be written to.</param>
    /// <returns>An integer 0.</returns>
    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        int returnVal = 0;
        const int messageCount = 5;
        for (int messageIndex = 0; messageIndex < messageCount; messageIndex++)
        {
            // Write a line based on whether the current year is greater than 2017.
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
        return returnVal;
    }
}
