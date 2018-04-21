using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposableExercise
{
    /// <summary>
    /// Defines an Automobile.
    /// </summary>
    public class Automobile : IDisposable
    {
        private bool disposed = false;

        public string NickName{ get; set; }

        /// <summary>
        /// Constructor that sets the nick name a person wants to give their automobile.
        /// </summary>
        /// <param name="nickName">The nick name of the Automobile.</param>
        public Automobile(string nickName)
        {
            NickName = nickName;
        }
        
        /// <summary>
        /// Pretty self explanatory, does automobile stuff.
        /// </summary>
        public void DoAutomobileStuff()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("Automobile");
            }
            Console.WriteLine("Vroom Vroom");
        }
        
        /// <summary>
        /// Disposes of managed resources and suppresses the finalizer call. 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; <c>False</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
           if (!this.disposed)
            {
                if (disposing)
                {

                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// Automobile is reclaimed by garbage collection.
        /// </summary>
        ~Automobile()
        {
            Dispose(false);
        }
    }
}
