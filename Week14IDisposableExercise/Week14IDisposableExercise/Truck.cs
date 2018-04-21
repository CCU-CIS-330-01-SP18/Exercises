using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposableExercise
{
    public class Truck : Automobile
    {
        //private bool disposed;

        public void BeReallyLoud()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException("Truck");
            }

            Console.WriteLine("Wow this truck is really loud!");
        }

        protected override void Dispose(bool disposing)
        {
            //IsDisposed = true;

            base.Dispose(disposing);
        }
    }
}
