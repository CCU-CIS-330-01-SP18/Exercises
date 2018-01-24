using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Writes a message to the user based on the year.
/// </summary>

class Program
{
    static DateTime dateTimeNow = DateTime.Now;

    /// <summary>
    /// This is the entry point for the program.
    /// </summary>
    /// <param name="args">The program Arugment.</param>
    /// <returns>
    /// Returns the Year Message based on the date passed.
    /// </returns>
   
    static int Main(string[] args)
    {
        return WriteMessage(dateTimeNow, Console.Out);
    }

    /// <summary>
    /// writes the messages based on the year, gets called in the Main method.
    /// </summary>
    /// <param name="currentDate">Current Date</param>
    /// <param name="writer">TextWriter Object that the output message is assigned to. </param>
    /// <returns>
    /// Returns the value of returnValue
    /// </returns>

    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        int returnValue = 0;
        const int messageCount = 5;

        for (int myIndex = 0; myIndex < messageCount; myIndex++)
        {
            // Checks if the current year is greater than 2017.
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
        return returnValue;
    }
}

