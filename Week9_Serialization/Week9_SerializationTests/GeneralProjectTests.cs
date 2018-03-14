using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week9_Serialization;

namespace Week9_SerializationTests
{
    [TestClass]
    public class GeneralProjectTests
    {
        [TestMethod]
        public void DoClassesInherit()
        {
            Platformer p = new Platformer();
            Strategy s = new Strategy();

            Assert.IsInstanceOfType(p, typeof(VideoGame));
            Assert.IsInstanceOfType(s, typeof(VideoGame));
        }

        [TestMethod]
        public void CanAddToList()
        {
            GameLibrary<VideoGame> testLibrary = new GameLibrary<VideoGame>();
            VideoGame testGame = new VideoGame("The Legend of Zelda: Breath of the Wild");
            testLibrary.Add(testGame);

            Assert.IsTrue(testLibrary.Contains(testGame));
        }
    }
}
