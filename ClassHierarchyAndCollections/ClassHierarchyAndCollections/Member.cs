using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Defines an Association member.
    /// </summary>
    public class Member : Individual, IQuitable
    {
        public int MemberID { get; set; }

        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Implements the IQuitable interface functionality. This person is able to quit their Association membership.
        /// </summary>
        public void Quit()
        {
            Console.WriteLine(this.DisplayName + " has decided to quit their membership.");
        }
    }
}
