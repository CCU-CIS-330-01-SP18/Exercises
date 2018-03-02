using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

///Need to add logic from CalculateFolderSize to make GetDirectorSize have failsafes

namespace Week7Threading
{
    /// <summary>
    /// A Class that creates and writes a text file and contains a method to read the size of a directory.
    /// </summary>
    public class ThreadingProgram
    {

        /// <summary>
        /// A method that creates a directory with a text file within it.
        /// </summary>
        /// <param name="args"> Takes a string parameter.</param>
        static void Main(string[] args)
        {
            string folderName = @"c:\Secret Contents";
            string pathString = Path.Combine(folderName, "You_Better_Watch_Out");
            Directory.CreateDirectory(pathString);

            string fileName = "You_Better_Not_Cry.txt";

            pathString = Path.Combine(pathString, fileName);

            if (!File.Exists(pathString))
            {
                using (StreamWriter sw = File.CreateText(pathString))
                {
                    sw.WriteLine("Hello, and welcome to the file that you're going to delete because it's annoying (if you notice it mwahaha). Chadderbox Was Here!");
                }
                GetFileSize(@"C:\Secret Contents");

            }
            else
            {
                GetFileSize(@"C:\Secret Contents");
            }
        }

        /// <summary>
        /// A method that finds the file length of the string parameter passed to it.
        /// This method is public in order to properly test it.
        /// </summary>
        /// <param name="directory"> A string parameter that needs to be formatted as a specific directory.</param>
        /// <returns> This method returns the calculated file length as a long.</returns>
        public static long GetFileSize(string directory)
        {

            long fileLength = 0;
            if (directory == "")
            {
                throw new DirectoryNotFoundException("That file doesn't exist");
            }
            
            if (!File.Exists(directory))
            {
                // Gets array of all file names recursively.
                string[] allFiles = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

               // Calculating the length of the file in a loop using threading.
                Parallel.ForEach(allFiles, currentFile =>
                {
                    FileInfo info = new FileInfo(currentFile);
                    fileLength += info.Length;
                    Console.WriteLine("Processing {0} on thread {1}", info, Thread.CurrentThread.ManagedThreadId);
                });

                long fileLengthKilobytes = fileLength / 1000;
                Console.WriteLine("The file created is " + fileLength + " bytes, or about " + fileLengthKilobytes + " kilobytes.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return fileLength;
            }

            else
            {
                throw new UnauthorizedAccessException("You do not have access to this file.");
            }
        }
    }
}
