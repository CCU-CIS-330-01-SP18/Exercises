using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposable
{
    /// <summary>
    /// Represents an asset, such as an agent or informant.
    /// </summary>
    public class Asset : IDisposable
    {
        private bool disposedValue = false;
        protected int clearanceLevel = 1;
        private string assetName;

        public int ClearanceLevel
        {
            get
            {
                return clearanceLevel;
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

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        /// <summary>
        /// Method to allow for manual disposal of this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
