using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotDisposable
{
    /// <summary>
    /// A carefully constructed thing that should not be disposed.
    /// </summary>
    public class SomethingThatShouldNotBeDisposed
    {
        /// <summary>
        /// Uses willpower to stop disposal.
        /// </summary>
        /// <returns>A live narration of the events that just took place.</returns>
        public string RefrainFromDisposing()
        {
            return "With the strained used of your willpower, you've refrained from disposing this class.";
        }
    }
}
