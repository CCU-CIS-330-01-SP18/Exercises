using CompareDir;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompareDirTests
{
    [TestClass]
    public class MultiThreadingTests
    {
        [TestMethod]
        public void CanCountFilesInDirectory()
        {
            Assert.AreNotEqual(0, MultiThreading.GetFileCountRecursive("C:\\Windows\\Fonts"));
        }
    }
}
