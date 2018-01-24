using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///     This class prints the current date to the console.
/// </summary>
class Program
{
    /// <summary>
    ///     This calls the WriteMessage method.
    /// </summary>
    /// <param name="args"></param>
    /// <returns>
    ///     This method returns the value of retValue field used in WriteMessage.
    /// </returns>
    // This is the entry point for the program.
    static int Main(string[] args)
    {
        return WriteMessage(dateNow, Console.Out);
    }

    static DateTime dateNow = DateTime.Now;

    /// <summary>
    ///     This method prints welcome messages based on the current year.
    /// </summary>
    /// <param name="currentDate">
    ///     This is the "dateNow" field which holds the present date and time.
    /// </param>
    /// <param name="writer">
    ///     The "writer" is simply Console.Out as distinguished in Main
    /// </param>
    /// <returns>
    ///     This method returns 0.
    /// </returns>
    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        int returnValue = 0;
        const int messageCount = 5;

        for (int currentCount = 0; currentCount < messageCount; currentCount++)
        {
            // This statement will equate to true if the date is greater than 2017.
            if (currentDate.Year > 2017)
            {
                writer.WriteLine("Happy New Year!");
            }
            else
            {
                writer.WriteLine("Hello From " + currentDate.Year);
            }
        }
        // Return the result of returnValue.
        return returnValue;
    }
}

