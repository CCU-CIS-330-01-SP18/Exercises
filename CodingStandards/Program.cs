using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Writes a message depending on the current date.
/// </summary>
class Program
{
    /// <summary>
    /// This is the entry point for the program. Executes WriteMessage() method
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    /// <returns>Returns standard error value.</returns>
    static int Main(string[] args)
    {
        // Return the return value of WriteMessage method.
        return WriteMessage(time, Console.Out);
    }
    static DateTime time = DateTime.Now;
    /// <summary>
    /// Writes a message to the console depending on the current date and time.
    /// </summary>
    /// <param name="currentDate">Represents the current time and date.</param>
    /// <param name="writer">Represents a writer instance from the TextWriter Class.</param>
    /// <returns>Returns standard error value.</returns>
    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        int returnValue = 0;
        const int messageCount = 5;
        // Iterates for the value of messageCount constant.
        for (int counter = 0; counter < messageCount; counter++)
        {
            // Greater than 2017.
            if (currentDate.Year > 2017)
            {
                writer.WriteLine("Happy New Year!");
            }
            // Less than 2017.
            else
                writer.WriteLine("Hello From " + currentDate.Year);
        }
        // Return the result value.
        return returnValue;
    }
}