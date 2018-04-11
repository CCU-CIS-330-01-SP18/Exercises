using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13Security;

namespace Week13SecurityTests
{
    [TestClass]
    public class HashingTests
    {
        [TestMethod]
        public void CanHashFile()
        {
            string rootPath = "C:\\test.txt";
            string libraryPath = "test.txt";
            var rootFile = File.CreateText(rootPath);
            rootFile.WriteLine("Hash THIS");
            rootFile.Close();

            // The files are completely identical copies of each other.
            File.Copy(rootPath, libraryPath);

            var readFile = File.OpenRead(rootPath);
            var libraryFile = File.OpenRead(libraryPath);
            
            byte[] rootHashed = Hashing.Hash(readFile);
            byte[] libraryHashed = Hashing.Hash(libraryFile);

            // Since the files are identical, the hashes should also be identical.
            Assert.IsTrue(rootHashed.SequenceEqual(libraryHashed), "Hashes are not identical.");

            readFile.Close();
            libraryFile.Close();

            // Modify the file. This should change the hash calculated from it.
            libraryFile = File.OpenWrite(libraryPath);
            libraryFile.WriteByte(3);
            libraryFile.Close();

            libraryFile = File.OpenRead(libraryPath);

            libraryHashed = Hashing.Hash(libraryFile);

            // A single byte is all the difference between the files, but the hash should be radically different.
            Assert.IsFalse(rootHashed.SequenceEqual(libraryHashed), "Hash is identical after file modification.");

            libraryFile.Close();

            File.Delete(rootPath);
            File.Delete(libraryPath);
        }
    }
}
