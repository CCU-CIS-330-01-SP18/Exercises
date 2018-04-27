using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN
{
    /// <summary>
    /// A serializable User class.
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// The user's email address.
        /// </summary>
        public string EmailAddress { get; private set; }

        /// <summary>
        /// The user's ID.
        /// </summary>
        public int UserID { get; private set; }

        /// <summary>
        /// The user's hashed email + password.
        /// </summary>
        public string HashedPassword { get; private set; }

        /// <summary>
        /// The number of points this user owns.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// A string representation of the last date the user logged in.
        /// </summary>
        public string LastLogin { get; set; }

        /// <summary>
        /// Constructs a new User object.
        /// </summary>
        /// <param name="first">The first name.</param>
        /// <param name="last">The last name.</param>
        /// <param name="email">The email address.</param>
        /// <param name="id">The user ID.</param>
        /// <param name="pass">The user's hashed password.</param>
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
