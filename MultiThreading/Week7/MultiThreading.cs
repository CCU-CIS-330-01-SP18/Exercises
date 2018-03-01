using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CompareDir
{
    /// <summary>
    /// Main program class. The program's execution begins here.
    /// </summary>
    public class MultiThreading
    {
        /// <summary>
        /// Entry point for the program. The program's execution begins here, and ends with the results being written to console.
        /// </summary>
        /// <param name="args">An array of arguments supplied by the user at the command line.</param>
        public static void Main(string[] args)
        {
            /*
             A NOTE TO THE REVIEWERS:
             This is a console app, and as such is run from the command line.
             To run this program, open a command window in the bin/release folder, specify Week7.exe as well as any arguments after it.
             For example, to evaluate the contents of C:\Users, I would type 'Week7.exe "C:\Users" -e'.
             In the case that you cannot or do not want to get your command line to work, I have included default arguments in case you just run it from VS.
             It will evaluate C:\Windows\Fonts and C:\Windows\Cursors by default, since everyone running Windows should have those two directories.
            */
            if (args.Length == 0)
            {
                System.Console.WriteLine("No arguments specified. Using demonstration values.");
                System.Console.WriteLine(Parse(new string[] { "C:\\Windows\\Fonts", "C:\\Windows\\Cursors", "-e", "-c" }));
            }
            else
            {
                System.Console.WriteLine(Parse(args));
            }
        }

        /// <summary>
        /// Parses a string array of arguments and returns the method to perform on them.
        /// </summary>
        /// <param name="args">An array of arguments to parse.</param>
        /// <returns></returns>
        private static string Parse(string[] args)
        {
            // This HashSet exists to store all of the methods that will be run, until the entire list of arguments has been parsed.
            var operations = new HashSet<DirectoryOperation>();
            var paths = new List<string>();
            string output = "---- Directory Size Evaluator Output ----\n";
            DirectoryOperation compare = Compare;
            DirectoryOperation evaluate = Evaluate;

            for (int i = 0; i < args.Length; i++)
            {
                // Find two (probably) valid paths in the arguments.
                if (Regex.IsMatch(args[i], @"^[A-Za-z]:\\.*"))
                {
                    paths.Add(args[i]);
                }
                else if (Regex.IsMatch(args[i], @"^[-/][EeSs]$"))
                {
                    operations.Add(evaluate);
                }
                else if (Regex.IsMatch(args[i], @"^[-/][Cc]$"))
                {
                    operations.Add(compare);
                }
                else if (Regex.IsMatch(args[i], @"^[-/][Hh]$"))
                {
                    return "---- Directory Size Evaluator Help ----\n\n" +
                           "-- Usage: Week7.exe <args> [flags]\n" +
                           "- \"args\" may contain as many valid file paths as you like, in any order.\n\n" +
                           "-- Flags: \n" +
                           "-c: compare the sizes of all given directories\n" +
                           "-e -s: calculate the size of the given directory\n" +
                           "-h: display this help screen\n";
                }
            }

            if (paths.Count == 0)
            {
                output += "No valid file paths supplied! Please specify one or more file paths that lead to directories to evaluate.";
                return output;
            }

            try
            {
                foreach (DirectoryOperation operation in operations)
                {
                    output += operation(paths);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                output += ex.Message + "\nThe program will now terminate.";
            }
            catch (PathTooLongException ex)
            {
                output += ex.Message + "\nThis error could also be caused by one of the files or folders inside the ones specified." +
                                       "\nThe program will now terminate.";
            }
            catch (AggregateException ex)
            {
                output += ex.Message + "\n" + ex.StackTrace + "\nThe program will now terminate.";
            }

            return output;
        }

        /// <summary>
        /// Delegate type. Accepts a list of directory paths to operate on and returns a string with the results of the operation.
        /// </summary>
        /// <param name="directoryList">A list of directory paths to operate on.</param>
        /// <returns>A string detailing the results of the operation.</returns>
        private delegate string DirectoryOperation(List<string> directoryList);

        /// <summary>
        /// Compares the sizes of a list of directories and all subfolders inside them.
        /// </summary>
        /// <param name="paths">A list of paths to directories to compare.</param>
        /// <returns>A string detailing the results of the comparison.</returns>
        private static string Compare(List<string> paths)
        {
            // If the user attempts to compare only one directory, just evaluate that directory's size instead.
            if (paths.Count == 1)
            {
                return "Only one directory was supplied. Evaluating size of directory instead.\n" +
                       Evaluate(paths);
            }

            object padlock = new object();
            var directorySizes = new Dictionary<string, long>();
            var orderedDirectoryOutputList = new List<string>();
            string report = "\n---- Compare Report ----\n" +
                            "(Ordered by size, descending)\n\n";

            foreach (string path in paths)
            {
                long size = Task<long>.Factory.StartNew((directory) => GetByteSizeRecursive((string)directory), path).Result;
                lock (padlock)
                {
                    directorySizes.Add(path, size);
                }
            }

            // Prepare the results to be output in order of size.
            while (directorySizes.Count > 0)
            {
                string largestDirectory = String.Empty;

                // Figure out which directories are the largest.
                foreach (string directory in directorySizes.Keys)
                {
                    if (string.IsNullOrEmpty(largestDirectory))
                    {
                        largestDirectory = directory;
                    }
                    else
                    {
                        if (directorySizes[directory] > directorySizes[largestDirectory])
                        {
                            largestDirectory = directory;
                        }
                    }
                }
                orderedDirectoryOutputList.Add("\"" + largestDirectory + "\": " + directorySizes[largestDirectory].ToString() + " bytes");
                directorySizes.Remove(largestDirectory);
            }

            // Assemble the report.
            foreach (string result in orderedDirectoryOutputList)
            {
                report += (orderedDirectoryOutputList.IndexOf(result) + 1).ToString() + ": " + result + "\n";
            }

            report += "\n---- END OF COMPARE REPORT ----\n";
            return report;
        }

        /// <summary>
        /// Evaluate the size of the directory at the given path and return a string detailing the results.
        /// </summary>
        /// <param name="path">The path to the directory to evaluate.</param>
        /// <returns>A string detailing the results.</returns>
        private static string Evaluate(List<string> paths)
        {
            long size = 0;
            long subDirectoryCount = 0;
            long fileCount = 0;

            foreach (string path in paths)
            {
                var sizeTask = Task<long>.Factory.StartNew((directory) => GetByteSizeRecursive((string)directory), path);
                var subDirectoryCountTask = Task<long>.Factory.StartNew((directory) => GetDirectoryCountRecursive((string)directory), path);
                var fileCountTask = Task<long>.Factory.StartNew((directory) => GetFileCountRecursive((string)directory), path);
                Interlocked.Add(ref size, sizeTask.Result);
                Interlocked.Add(ref subDirectoryCount, subDirectoryCountTask.Result);
                Interlocked.Add(ref fileCount, fileCountTask.Result);
            }
            
            string report = "\n---- Evaluate Report ----\n";
            report += "- Directories Evaluated:\n";
            foreach (string path in paths)
            {
                report += "\"" + path + "\"\n";
            }
            report += "- Total Size: " + size + " bytes\n";
            report += "- Total Number of Folders: " + subDirectoryCount + " folders\n";
            report += "- Total Number of Files: " + fileCount + " files\n";
            report += "\n---- END OF EVALUATE REPORT ----\n";
            return report;
        }

        /// <summary>
        /// Gets and returns the size of the directory at the given address, in bytes.
        /// </summary>
        /// <param name="path">The path to the directory to evaluate.</param>
        /// <returns>The size of the directory in bytes.</returns>
        private static long GetByteSizeRecursive(string path)
        {
            long size = 0;
            try
            {
                if (Directory.Exists(path))
                {
                    if (Directory.GetFiles(path).Length > 0)
                    {
                        foreach (string file in Directory.GetFiles(path))
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            size += fileInfo.Length;
                        }
                    }

                    if (Directory.GetDirectories(path).Length > 0)
                    {
                        foreach (string folder in Directory.GetDirectories(path))
                        {
                            size += GetByteSizeRecursive(folder);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }

            return size;
        }

        /// <summary>
        /// Gets and returns the number of directories contained in the directory at the given address.
        /// </summary>
        /// <param name="path">The path to the directory to evaluate.</param>
        /// <returns>The number of directories found, including the root directory; or 0 if the root directory does not exist.</returns>
        private static long GetDirectoryCountRecursive(string path)
        {
            long count = 0;

            if (Directory.Exists(path))
            {
                count = 1;
                if (Directory.GetDirectories(path).Length > 0)
                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        count += GetDirectoryCountRecursive(folder);
                    }
            }

            return count;
        }

        /// <summary>
        /// Gets and returns the number of files contained in the directory at the given address.
        /// </summary>
        /// <param name="path">The path to the directory to evaluate.</param>
        /// <returns>The number of files found.</returns>
        private static long GetFileCountRecursive(string path)
        {
            long count = 0;

            if (Directory.Exists(path))
            {
                if (Directory.GetFiles(path).Length > 0)
                {
                    foreach (string file in Directory.GetFiles(path))
                    {
                        count++;
                    }
                }

                if (Directory.GetDirectories(path).Length > 0)
                {
                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        count += GetFileCountRecursive(folder);
                    }
                }
            }

            return count;
        }
    }
}
