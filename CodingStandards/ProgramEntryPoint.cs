using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    // This is the entry point for the program
   
    static DateTime datetimeNow = DateTime.Now;
    static int Main(string[] args)
{
    return WriteMessage(datetimeNow, Console.Out);
}

    /// <summary>
    /// Determines if 2017 has passed or not. If so, it greets the user with "Happy New Year!" If not it greets from the given year.
    /// </summary>
    /// <param name="currentDate">This expresses the current date as a DateTime object.</param>
    /// <param name="writer">A text writer object that is responsible for relaying the message to the user.</param>
    /// <returns>Returns the result value: 0</returns>
public static int WriteMessage(DateTime currentDate, TextWriter writer)
{
    var resultValue = 0;
    const int messageCount = 5;
        for (int index = 0; index < messageCount; index++)
        {
            // When the current time is past 2017, greet the user with a "Happy New Year!"
            if (currentDate.Year > 2017)
            {
                writer.WriteLine("Happy New Year!");
            }
            else
            {
                writer.WriteLine("Hello From " + currentDate.Year);
            }
        }
    // Returns the result value.
    return resultValue;
    }
}

