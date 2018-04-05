using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12Reflection
{
    /// <summary>
    /// Represents an instance of a GIF.
    /// </summary>
    public class GIF
    {
        /// <summary>
        /// The title of the GIF.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Displays how funny the GIF is calculated on a scale from 1-10.
        /// </summary>
        public int HumorScore { get; set; }

        /// <summary>
        /// Makes the person who looks at the GIF, laugh.
        /// </summary>
        public void MakeMeLaugh() { }

    }
}
