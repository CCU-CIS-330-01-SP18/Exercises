using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposableExercise
{
    /// <summary>
    /// Creates a popular movie about the Avengers.
    /// </summary>
    public class InfinityWar : Avengers
    {
        private bool disposed;

        public string DateReleased { get; set; }

        public string Summary { get; set; }


        /// <summary>
        /// Disposes of resources.
        /// </summary>
        /// <param name="disposing">A boolean to dictate whether of not to dispose of it.</param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DateReleased = null;
                    Summary = null;
                }
            }
            disposed = true;
        }
    }
}