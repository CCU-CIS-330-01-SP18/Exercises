using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflecting
{
    /// <summary>
    /// Posesses the 2 properties and 1 method relevant to an prisoner in the 14th century.
    /// </summary>
    public class Prisoner
    {
        private string LastWords { get; set; }
        private bool IsCrying { get; set; }

        /// <summary>
        /// Kills the prisoner.
        /// </summary>
        private void Die()
        {
        }
    }
}
