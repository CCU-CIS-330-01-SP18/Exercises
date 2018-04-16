using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposableExercise
{
    class Dog : Animal, IDisposable
    {
        private bool disposed;

        public void DoDogWork()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("Dog");
            }

            Console.WriteLine("This dog is doing some work!");
        }

        protected override void Dispose(bool disposing)
        {
            this.disposed = true;

            base.Dispose(disposing);
        }
    }
}
