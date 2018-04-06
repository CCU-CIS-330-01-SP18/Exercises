using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12Reflection
{
    /// <summary>
    /// A class that represents a mobile phone manufacured by Samsung. 
    /// </summary>
    public class GalaxyNote7
    {
        public bool IsAllowedThroughTSA { get; set; }

        public bool IsOverpriced { get; set; }

        /// <summary>
        /// Initiates device's primary directive. 
        /// </summary>
        public void Detonate()
        {
            Console.WriteLine("**BOOM**");
            this.IsAllowedThroughTSA = false;
        }
    }
}
