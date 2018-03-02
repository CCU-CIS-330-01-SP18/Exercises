using System;
using System.Collections.Generic;
using System.Text;

namespace Week7Threading
{
    /// <summary>
    /// A type of mineral that is worth 5.
    /// </summary>
    public class Silver: Mineral
    {
        /// <summary>
        /// Defines the name, mining time, and value of silver.
        /// </summary>
        public Silver(): base("Silver", 5000, 5)
        {
        }
    }
}
