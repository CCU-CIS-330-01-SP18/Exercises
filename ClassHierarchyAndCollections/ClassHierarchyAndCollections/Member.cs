using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Provides the details of a member.
    /// </summary>
    public class Member: Individual, IBookLunchDate
    {
        public String LevelOfMembership { get; set; }

        public String DateJoined { get; set; }

        /// <summary>
        /// Books a lunch date with the designated member
        /// </summary>
        public void BookLunchDate()
        {
            Console.WriteLine("You have booked a lunch date with: " + this.DisplayName);
        }
    }
}
