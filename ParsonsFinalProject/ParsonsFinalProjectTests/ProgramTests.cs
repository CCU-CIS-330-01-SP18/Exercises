using System;
using System.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsonsFinalProject;

namespace ParsonsFinalProjectTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CanEncrypt()
        {
            var pathAndName = AppDomain.CurrentDomain.BaseDirectory + @"\voice.mp3";
            var encrypt = Program.EncryptFile(pathAndName);
            Assert.IsNotNull(pathAndName);
        }

    }
}
