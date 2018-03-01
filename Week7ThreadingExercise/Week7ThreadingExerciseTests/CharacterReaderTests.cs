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

            string content = "Data.txt";

            FileInfo file = new FileInfo(content);

            Assert.AreEqual(file.Length, task.Result);
        }
    }
}
