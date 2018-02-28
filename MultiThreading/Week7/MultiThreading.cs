using System;
using System.Collections.Generic;
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
            System.Console.WriteLine(Parse(args));
        }
        
        /// <summary>
        /// Parses a string array of arguments and returns the method to perform on them.
        /// </summary>
        /// <param name="args">An array of arguments to parse.</param>
        /// <returns></returns>
        private static string Parse(string[] args)
        {
            var paths = new List<string>();
            var operations = new HashSet<DirectoryOperation>();
            string output = "---- Directory Size Evaluator Output ----\n\n";
            //DirectoryOperation compare = delegate (List<string> directoryList) { return String.Empty; };
            DirectoryOperation evaluate = Evaluate;
            //DirectoryOperation validate = delegate (List<string> directoryList) { return String.Empty; };
            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    // Find two (probably) valid URIs in the arguments.
                    if (Regex.IsMatch(args[i], @"^[A-Za-z]:\\([\w]*\\)"))
                    {
                        paths.Add(args[i]);
                    }
                    else if (Regex.IsMatch(args[i], @"^[-/][EeSs]$"))
                    {
                        // TODO: Define delegates
                        operations.Add(evaluate);
                    }
                    else if (Regex.IsMatch(args[i], @"^[-/][Hh]$"))
                    {
                        return "---- Directory Size Evaluator Help ----\n\n" +
                               "-- Usage: Week7.exe <args> [flags]\n" +
                               "- args may be as many valid file paths as you like.\n\n" +
                               "-- Flags: \n" +
                               "-e -s: calculate the size of the given directory\n" +
                               "-h: display this help screen\n";
                    }
                }
            }
            catch (Exception)
            {
                // TODO: Don't catch Exception
                throw;
            }

            foreach (DirectoryOperation operation in operations)
            {
                output += operation(paths);
            }

            return output;
        }

        /// <summary>
        /// Delegate type. Accepts a list of URIs to operate on and returns a string with the results of the operation.
        /// </summary>
        /// <param name="directoryList">A list of URIs to operate on.</param>
        /// <returns>A string detailing the results of the operation.</returns>
        private delegate string DirectoryOperation(List<string> directoryList);

        /// <summary>
        /// Delegate type. Accepts a path to evaluate and gets the size of the directory at the given path.
        /// </summary>
        /// <param name="path">The path to the directory to evaluate.</param>
        /// <returns>The size of the directory.</returns>
        //private delegate long Func<string, long> SizeOperation(string path);

        /// <summary>
        /// Compares the size of two directories and all subfolders inside them.
        /// </summary>
        /// <param name="directoryList">A list of URIs to compare.</param>
        /// <returns>A string detailing the results of the comparison.</returns>
        private static string Compare(List<string> directoryList)
        {
            Func<string, long> getSize = GetByteSizeRecursive;
            foreach (string directory in directoryList)
            {
                //long size = Task.Factory.StartNew<long>(getSize);
            }

            return null;
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
            report += "- Total Size: " + size + " bytes\n";
            report += "- Total Number of Folders: " + subDirectoryCount + " folders\n";
            report += "- Total Number of Files: " + fileCount + " files\n";
            report += "---- END OF EVALUATE REPORT ----\n";
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
