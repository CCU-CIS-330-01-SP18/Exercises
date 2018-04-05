using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12Reflection
{
    /// <summary>
    /// Represents an instance of a Meme.
    /// </summary>
    public class Meme
    {
        /// <summary>
        /// The title of the Meme.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Displays how funny the Meme is calculated on a scale from 1-10.
        /// </summary>
        public int HumorScore { get; set; }

        /// <summary>
        /// Makes the person who looks at the Meme, laugh.
        /// </summary>
        /// <returns>The lovely sound of laughter.</returns>
        public string MakeMeLaugh()
        {
            return "Haha";
        }
    }
}
