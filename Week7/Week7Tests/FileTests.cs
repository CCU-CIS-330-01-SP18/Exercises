using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7;

namespace Week7Tests
{
    [TestClass]
    public class FileTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string content = @"c:\Data\Data.txt";
            File file = new File();
            file.FileName = content;

            int contentLength = file.CountCharacters();

            Assert.AreEqual(367, contentLength);
            
        }
    }
}
