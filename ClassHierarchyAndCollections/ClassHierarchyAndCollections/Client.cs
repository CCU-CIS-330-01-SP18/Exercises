using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines a business client or contact.
    /// </summary>
    class Client : Individual, IQuit
    {
        public int ClientID { get; set; }

        public ClientPriority Priority { get; set; }

        /// <summary>
        /// Implement the function to quit. This is usually seen during protests, boycotts, and economic depressions.
        /// </summary>
        public void Quit()
        {
            Console.WriteLine(this.DisplayName + " has decided to quit giving money to a business.");
        }
    }
}
