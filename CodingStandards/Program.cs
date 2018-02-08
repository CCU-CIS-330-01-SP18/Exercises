using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Writes out using the Console a specified message based on certain conditions.
/// </summary>
class Program
{
    static DateTime dtNow = DateTime.Now;
    /// <summary>
    /// This is the entry point for the program.
    /// </summary>
    /// <param name="args">Includes an array  of type string that can be passed and utilized.</param>
    /// <returns>Returns the ouput of calling the Method WriteMessage.</returns>
    static int Main(string[] args)
    {
        return WriteMessage(dtNow, Console.Out);
    }

    /// <summary>
    /// Writes out a string based upon meeting certain conditions.
    /// </summary>
    /// <param name="currentDate">A specified date wanting to be analyzed.</param>
    /// <param name="writer">Holds a TextWriter object which is used to display a string.</param>
    /// <returns>Returns an integer of 0.</returns>
    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        int returnValue = 0;
        const int messageCount = 5;
        for (int myIndex = 0; myIndex < messageCount; myIndex++)
        {
            // Outputs Happy New Year to the TextWriter if the current year is greater than 2017.
            if (currentDate.Year > 2017)
            {
                writer.WriteLine("Happy New Year!");
            }
            else
            {
                writer.WriteLine("Hello From " + currentDate.Year);
            }
        }
        // returns the value 0 which is held in the declaration returnValue.
        return returnValue;
    }
}

