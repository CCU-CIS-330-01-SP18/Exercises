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
    class GalaxyNote7
    {
        public bool IsAllowedTroughTSA { get; set; }

        public bool IsOverpriced { get; set; }

        /// <summary>
        /// Initiates device's primary directive. 
        /// </summary>
        public void EmptyBankAccount()
        {
            Console.WriteLine("**BOOM**");
            this.IsAllowedTroughTSA = false;
        }
    }
}
