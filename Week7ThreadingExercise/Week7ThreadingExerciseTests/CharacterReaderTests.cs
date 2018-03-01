using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week7ThreadingExercise;
using System.IO;
using System.Threading.Tasks;

namespace Week7ThreadingExerciseTests
{
    [TestClass]
    public class CharacterReaderTests
    {
        [TestMethod]
        public void CharacterReaderCanReadAndCountCharactersFromATextFile()
        {
            Task<int> task = CharacterReader.CountCharacters();

            // Similarly to the CharacterReader class I added the same text file to 
            // Week7ThreadingExerciseTests\bin\Debug
            string content = "Data.txt";
            
            // This allows me to access properties and methods to interact with a file.
            FileInfo file = new FileInfo(content);

            Assert.AreEqual(file.Length, task.Result);
        }
    }
}
