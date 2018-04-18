using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week14IDisposable;

namespace Week14IDisposableTests
{
    [TestClass]
    public class AssetTests
    {
        [TestMethod]
        public void CanDisposeAsset()
        {
            string name = "James Bond";
            int clearance = 7;
            var asset = new Asset(name, clearance);
            Assert.AreEqual(name, asset.AssetName);

            asset.Dispose();
            Assert.IsNull(asset.AssetName);
        }
    }
}
