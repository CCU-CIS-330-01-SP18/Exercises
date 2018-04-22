using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposableExercise
{
    /// <summary>
    /// Defines the Avengers class.
    /// </summary>
    public class Avengers : IDisposable
    {
        private bool disposed = false;

        public string SuperPowers { get; set; }

        public string Name { get; set; }



        /// <summary>
        /// Disposes of managed and unmanaged resources and requests the system does not call the finalizer.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of resources.
        /// </summary>
        /// <param name="disposing">A boolean to dictate whether of not to dispose of it.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    SuperPowers = null;
                    Name = null;
                }
            }
            disposed = true;
        }

    }
}