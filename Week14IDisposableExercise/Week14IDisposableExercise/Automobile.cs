using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposableExercise
{
    public class Automobile : IDisposable
    {
        public bool IsDisposed { get; private set; }
        private Automobile automobile = new Automobile();
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            IsDisposed = true;
            if (disposing)
            {
                if (automobile != null)
                {
                    automobile.Dispose();
                    automobile = null;
                }
            }
        }

        ~Automobile()
        {
            Dispose(false);
        }
    }
}
