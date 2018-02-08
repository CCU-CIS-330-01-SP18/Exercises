using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    class Individual: Contact, IBookLunchDate
    {
        public String PhoneNumber { get; set; }

        public String MarritalStatus { get; set; }

        public void BookLunchDate(string name)
        {
            Console.WriteLine("You have booked a lunch date with: " + name);
        }
    }
}
