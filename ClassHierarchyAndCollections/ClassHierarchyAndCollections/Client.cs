using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Provides the details of a business client.
    /// </summary>
    class Client: Individual, IBookLunchDate
    {
        public String ClientBusiness { get; set; }

        public String ClientCreditStanding { get; set; }

        /// <summary>
        /// Books a lunch date with a particular client.
        /// </summary>
        public void BookLunchDate()
        {
            Console.WriteLine("You have booked a lunch date with: " + this.DisplayName);
        }
    }
}
