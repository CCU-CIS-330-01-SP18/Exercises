using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

///Need to add logic from CalculateFolderSize to make GetDirectorSize have failsafes
/// It's now recursive and parallel, but faulty at accuracy.

namespace Week7Threading
{
    class Week7Threading
    {
        static object countLock = new object();

        static void Main(string[] args)
        {
            GetFileSize(@"C:\Program Files\Common Files");
            //GetFileSize(@"C:\backups");
        }
        static long GetFileSize(string directory)
        {
            // Gets array of all file names recursively.
            string[] allFiles = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            /*
            catch
            {
                NotSupportedException("Unable to calculate folder size: {0}");
            }
            */

            // Calculating total bytes of all files in a loop.
            long fileLength = 0;
            Parallel.ForEach(allFiles, currentFile =>
            {
                //(string name in allFiles)
                // FileInfo gets the length of each file
                FileInfo info = new FileInfo(currentFile);
                fileLength += info.Length;
                Console.WriteLine("Processing {0} on thread {1}", info, Thread.CurrentThread.ManagedThreadId);
            });

            // Returns total size of file.
           var fileLengthMegabytes =  fileLength / 1000000;
            Console.WriteLine("The file chosen is "+fileLength+" bytes, or about "+fileLengthMegabytes+" megabytes.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return fileLength;
        }
        /*
        static long GetDirectorySize(string directory)
        {
                
                    // Recursively scan directories.
                    string[] a = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
                    // 2.
                    // Calculate total bytes of all files in a loop.
                    long fileSize = 0;
                    foreach (string name in a)
                    {
                        if (File.Exists(directory))
                        {
                            // 3.
                            // Use FileInfo to get length of each file.
                            FileInfo info = new FileInfo(name);
                            fileSize += info.Length;
                            // 4.
                            // Return total size
                            Console.WriteLine(fileSize);
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Unable to calculate folder size: {0}");
                            //Console.ReadKey();
                            //throw new NotSupportedException("Unable to calculate folder size: {0}");
                            //UnauthorizedAccessException
                        };
                    }
            return fileSize ;
        }
        */
    }
}
