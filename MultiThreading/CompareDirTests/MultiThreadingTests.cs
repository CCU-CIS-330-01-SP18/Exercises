using CompareDir;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace CompareDirTests
{
    [TestClass]
    public class MultiThreadingTests
    {
        /*
         * A NOTE TO THE REVIEWERS:
         * This class looks a little sparse, mainly because of the way this program is set up.
         * Since the main methods that do things return a string for user consumption, effective unit tests are very difficult to write 
         * without some complicated parsing functions. I've done the best I can.
         */

        [TestMethod]
        public void CanCountSubDirectoriesInDirectory()
        {
            // A NOTE TO THE REVIEWERS:
            // It is possible for some shenanigans to happen with your filesystem that break these tests.
            // If this happens, delete "C:\EikeWeek7Testing" from your computer. That should make the tests work again.
            string testDirectoryRoot = "C:\\EikeWeek7Testing";
            Directory.CreateDirectory(testDirectoryRoot);
            for (int i = 0; i < 5; i++)
            {
                Directory.CreateDirectory(testDirectoryRoot + "\\test" + i.ToString());
            }

            Assert.AreEqual(6, MultiThreading.GetDirectoryCountRecursive(testDirectoryRoot));

            // Clean up the directories created for testing.
            foreach (string path in Directory.GetDirectories(testDirectoryRoot))
            {
                Directory.Delete(path);
            }
            Directory.Delete(testDirectoryRoot);
        }

        [TestMethod]
        public void CanCountFilesInDirectory()
        {
            // A NOTE TO THE REVIEWERS:
            // It is possible for some shenanigans to happen with your filesystem that break these tests.
            // If this happens, delete "C:\EikeWeek7Testing" from your computer. That should make the tests work again.
            string testDirectoryRoot = "C:\\EikeWeek7Testing";
            Directory.CreateDirectory(testDirectoryRoot);
            Directory.CreateDirectory(testDirectoryRoot + "\\testdir");
            for (int i = 0; i < 5; i++)
            {
                var testFile = File.Create(testDirectoryRoot + "\\test" + i.ToString());
                testFile.Close();
                var testSubFile = File.Create(testDirectoryRoot + "\\testdir\\test" + i.ToString());
                testSubFile.Close();
            }

            Assert.AreEqual(10, MultiThreading.GetFileCountRecursive(testDirectoryRoot));

            // Clean up the files created for testing.
            foreach (string path in Directory.GetFiles(testDirectoryRoot))
            {
                File.Delete(path);
            }
            foreach (string path in Directory.GetFiles(testDirectoryRoot + "\\testdir"))
            {
                File.Delete(path);
            }
            Directory.Delete(testDirectoryRoot + "\\testdir");
            Directory.Delete(testDirectoryRoot);
        }

        [TestMethod]
        public void CanGetSizeOfFilesInDirectory()
        {
            // A NOTE TO THE REVIEWERS:
            // It is possible for some shenanigans to happen with your filesystem that break these tests.
            // If this happens, delete "C:\EikeWeek7Testing" from your computer. That should make the tests work again.
            string testDirectoryRoot = "C:\\EikeWeek7Testing";
            Directory.CreateDirectory(testDirectoryRoot);
            Directory.CreateDirectory(testDirectoryRoot + "\\testdir");
            for (int i = 0; i < 5; i++)
            {
                var testFile = File.Create(testDirectoryRoot + "\\test" + i.ToString());
                testFile.WriteByte((byte)i);
                testFile.Close();
                var testSubFile = File.Create(testDirectoryRoot + "\\testdir\\test" + i.ToString());
                testSubFile.WriteByte((byte)i);
                testSubFile.Close();
            }

            Assert.AreEqual(10, MultiThreading.GetByteSizeRecursive(testDirectoryRoot));

            // Clean up the files created for testing.
            foreach (string path in Directory.GetFiles(testDirectoryRoot))
            {
                File.Delete(path);
            }
            foreach (string path in Directory.GetFiles(testDirectoryRoot + "\\testdir"))
            {
                File.Delete(path);
            }
            Directory.Delete(testDirectoryRoot + "\\testdir");
            Directory.Delete(testDirectoryRoot);
        }

        [TestMethod]
        public void CanEvaluateDirectory()
        {
            // A NOTE TO THE REVIEWERS:
            // It is possible for some shenanigans to happen with your filesystem that break these tests.
            // If this happens, delete "C:\EikeWeek7Testing" from your computer. That should make the tests work again.
            string testDirectoryRoot = "C:\\EikeWeek7Testing";
            var oneStringList = new List<string>
            {
                testDirectoryRoot
            };
            Directory.CreateDirectory(testDirectoryRoot);
            Directory.CreateDirectory(testDirectoryRoot + "\\testdir");
            for (int i = 0; i < 5; i++)
            {
                var testFile = File.Create(testDirectoryRoot + "\\test" + i.ToString());
                testFile.WriteByte((byte)i);
                testFile.Close();
                var testSubFile = File.Create(testDirectoryRoot + "\\testdir\\test" + i.ToString());
                testSubFile.WriteByte((byte)i);
                testSubFile.Close();
            }

            Assert.IsTrue(MultiThreading.Evaluate(oneStringList).Contains("Total Size: 10 bytes"));
            Assert.IsTrue(MultiThreading.Evaluate(oneStringList).Contains("Total Number of Folders: 2"));
            Assert.IsTrue(MultiThreading.Evaluate(oneStringList).Contains("Total Number of Files: 10"));

            // Clean up the files created for testing.
            foreach (string path in Directory.GetFiles(testDirectoryRoot))
            {
                File.Delete(path);
            }
            foreach (string path in Directory.GetFiles(testDirectoryRoot + "\\testdir"))
            {
                File.Delete(path);
            }
            Directory.Delete(testDirectoryRoot + "\\testdir");
            Directory.Delete(testDirectoryRoot);
        }

        [TestMethod]
        public void CompareEvaluatesWhenOneDirectorySupplied()
        {
            var oneStringList = new List<string>
            {
                "C:\\Fonts"
            };
            Assert.IsTrue(MultiThreading.Compare(oneStringList).Contains("Only one directory was supplied. Evaluating size of directory instead."));
        }

        [TestMethod]
        public void ParseWarnsWhenNoPathsSupplied()
        {
            var args = new string[]
            {
                "-e",
                "-c"
            };
            Assert.IsTrue(MultiThreading.Parse(args).Contains("No valid file paths supplied! Please specify one or more file paths that lead to directories to evaluate."));
        }
    }
}
