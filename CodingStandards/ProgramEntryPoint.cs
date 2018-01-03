using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
        //This is the entry point for the program.
        static int Main(string[] args)
{
    return writeMessage(dtNow, Console.Out);
}

        static DateTime dtNow = DateTime.Now;

public static int writeMessage(DateTime CurrentDate, TextWriter writer)
{
    var intRetVal = 0; const Int32 MESSAGE_COUNT = 5; for (int MyIndex = 0; MyIndex < MESSAGE_COUNT; MyIndex++)
    /*********************/
    /* greater than 2017 */
    /*********************/
    if (CurrentDate.Year > 2017) writer.WriteLine("Happy New Year!");
    else
                writer.WriteLine("Hello From " + CurrentDate.Year);


    //--------------------return the result value----------------------------




    return intRetVal;
    }
}

