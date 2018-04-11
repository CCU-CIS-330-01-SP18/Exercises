using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using Week13Security;

namespace Week13SecurityTests
{
    [TestClass]
    public class HashingTests
    {
        [TestMethod]
        public void CanHashFile()
        {
            string rootPath = "C:\\jay_test.txt";
            string libraryPath = "jay_test.txt";

            // In case these already exist for...some reason.
            File.Delete(rootPath);
            File.Delete(libraryPath);

            var rootFile = File.CreateText(rootPath);
            rootFile.WriteLine("Hash THIS");
            rootFile.Close();

            // The files are completely identical copies of each other.
            File.Copy(rootPath, libraryPath);
            
            byte[] rootHashed = Hashing.Hash(rootPath);
            byte[] libraryHashed = Hashing.Hash(libraryPath);

            // Since the files are identical, the hashes should also be identical.
            Assert.IsTrue(rootHashed.SequenceEqual(libraryHashed), "Hashes are not identical.");

            // Modify the file. This should change the hash calculated from it.
            var libraryFile = File.OpenWrite(libraryPath);
            libraryFile.WriteByte(3);
            libraryFile.Close();

            libraryHashed = Hashing.Hash(libraryPath);

            // A single byte is all the difference between the files, but the hash should be radically different.
            Assert.IsFalse(rootHashed.SequenceEqual(libraryHashed), "Hash is identical after file modification.");
            
            File.Delete(rootPath);
            File.Delete(libraryPath);
        }
    }
}
