using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7Threading;

namespace Week7ThreadingTests
{
    [TestClass]
    public class ThreadingProgramTests
    {
        [TestMethod]
        public void ThreadingProgramFileCreatedTest()
        {
            Assert.IsTrue(File.Exists(@"C:\Secret Contents\You_Better_Watch_Out\You_Better_Not_Cry.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException), "That file doesn't exist")]
        public void GetFileSizeDirectoryNotFoundCaughtException()
        {
            // This file path string obviously does not exist, so DirectoryNotFoundException would be called and caught.
            ThreadingProgram.GetFileSize(@"C:\thisDoesNotExist");
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException),"You do not have access to this file.")]
        public void GetFileSizeUnauthorizedCaughtException()
        {
            // This specific file path string is restriced and would be caught by GetFileSize method.
            ThreadingProgram.GetFileSize(@"C:\Users");
        }
    }
}
