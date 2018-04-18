using System;

namespace Week14IDisposable
{
    /// <summary>
    /// Represents an asset, such as an agent or informant.
    /// </summary>
    public class Asset : IDisposable
    {
        protected bool disposedValue = false;
        protected int clearanceLevel = 1;
        protected string assetName;

        public int ClearanceLevel
        {
            get
            {
                return clearanceLevel;
            }
        }

        public string AssetName
        {
            get
            {
                return assetName;
            }
        }

        /// <summary>
        /// Instantiates a new Asset object with the given codename and clearance level.
        /// </summary>
        /// <param name="name">The codename for the asset.</param>
        /// <param name="clearance">The clearance level for the asset.</param>
        public Asset(string name, int clearance)
        {
            assetName = name;
            clearanceLevel = clearance;
        }
        
        /// <summary>
        /// Dispose this object, freeing up resources.
        /// </summary>
        /// <param name="disposing">Whether or not to manually dispose managed state.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    assetName = null;
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Method to allow for manual disposal of this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
