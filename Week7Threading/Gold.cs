using System;
using System.Collections.Generic;
using System.Text;

namespace Week7Threading
{
    /// <summary>
    /// A type of mineral that is worth 10.
    /// </summary>
    public class Gold: Mineral
    {
        /// <summary>
        /// Defines the name, mining time, and value of gold.
        /// </summary>
        public Gold() : base("Gold", 10000, 10)
        {
        }
    }
}
