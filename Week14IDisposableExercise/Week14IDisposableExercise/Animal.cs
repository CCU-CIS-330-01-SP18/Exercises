using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposableExercise
{
    public class Animal : IDisposable
    {
        private Dog dog = new Dog();
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dog != null)
                {
                    dog.Dispose();
                    dog = null;
                }
            }
        }

        ~Animal()
        {
            Dispose(false);
        }
    }
}
