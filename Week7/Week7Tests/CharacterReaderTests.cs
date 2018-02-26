using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7;

namespace Week7Tests
{
    [TestClass]
    public class CharacterReaderTests
    {
        [TestMethod]
        public void CanReadAndCountCharacersFromATextFile()
        {
            string content = "Data.txt";
            CharacterReader reader = new CharacterReader();
            reader.FileName = content;

            FileInfo file = new FileInfo(content);

            int contentLength = reader.CountCharacters();

            Assert.AreEqual(file.Length, contentLength);            
        }
    }
}
