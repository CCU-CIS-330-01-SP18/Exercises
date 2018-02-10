using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A class for writing messages concerning the current year in relation to 2017.
/// </summary>
class ProgramEntryPoint
{
    /// <summary>
    /// The current date and time.
    /// </summary>
    static DateTime Now = DateTime.Now;

    /// <summary>
    /// Calls the WriteMessage method, passing in the current date as the first parameter and the console as the writing medium.
    /// </summary>
    /// <param name="args">A generic string array parameter.</param>
    /// <returns>The result of WriteMessage (which will always be 0).</returns>
    static int Main(string[] args)
    {
        return WriteMessage(Now, Console.Out);
    }

    /// <summary>
    /// Compares a date's year to 2017 and writes messages accordingly.
    /// </summary>
    /// <param name="currentDate">The date to compare to 2017.</param>
    /// <param name="writer">What to write the message to.</param>
    /// <returns>Will always return 0.</returns>
    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        int returnValue = 0;
        const int messageCount = 5;
        for (int myIndex = 0; myIndex < messageCount; myIndex++)
        {
            if (currentDate.Year > 2017)
            {
                writer.WriteLine("Happy New Year!");
            }
            else
            {
                writer.WriteLine("Hello From " + currentDate.Year);
            }
        }
        return returnValue;
    }
}

