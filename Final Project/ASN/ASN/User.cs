using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN
{
    [Serializable]
    public class User
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EmailAddress { get; private set; }

        public int UserID { get; private set; }

        public string HashedPassword { get; private set; }

        public int Points { get; set; }

        public string LastLogin { get; set; }

        public User(string first, string last, string email, int id, string pass)
        {
            FirstName = first;
            LastName = last;
            EmailAddress = email;
            UserID = id;
            HashedPassword = pass;
            Points = 10;
            LastLogin = DateTime.Today.ToString("dd-MM-yyyy");
        }
    }
}
