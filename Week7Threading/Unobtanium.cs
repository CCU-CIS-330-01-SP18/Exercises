using System;
using System.Collections.Generic;
using System.Text;

namespace Week7Threading
{
    /// <summary>
    /// A type of mineral that is worth 10,000.
    /// </summary>
    public class Unobtainium: Mineral
    {
        /// <summary>
        /// Defines the name, mining time, and value of unobtainium.
        /// </summary>
        public Unobtainium(): base("Unobtainium", 15000, 10000)
        {
        }
    }
}
