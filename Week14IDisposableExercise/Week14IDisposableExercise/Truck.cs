using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposableExercise
{
    /// <summary>
    /// Creates a Truck object.
    /// </summary>
    public class Truck : Automobile
    {
        private bool disposed;

        /// <summary>
        /// Constructor that sets the trucks nickname.
        /// </summary>
        /// <param name="nickName">The precious name for a truck.</param>
        public Truck(string nickName)
            : base(nickName)
        {
            nickName = base.NickName;
        }

        /// <summary>
        /// A method that causes frustration and annoyance to other drivers.
        /// </summary>
        public void BeReallyLoud()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("Truck");
            }

            Console.WriteLine("Wow this truck is really loud!");
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources;
        /// False to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            this.disposed = true;

            base.Dispose(disposing);
        }
    }
}
