using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12Reflection
{
    /// <summary>
    /// A class that represents a mobile phone manufactured by Apple. 
    /// </summary>
    public class IphoneX
    {
        public bool IsAllowedThroughTSA { get; set; }

        public bool IsOverpriced { get; set; }

        /// <summary>
        /// Displays bank account standing after purchase of iPhoneX.
        /// </summary>
        public void EmptyBankAccount()
        {
            Console.WriteLine("Your remaining bank balance is $0.00");
            this.IsOverpriced = true;
        }
    }
}

