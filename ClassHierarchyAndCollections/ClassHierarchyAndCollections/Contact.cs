using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a contact, with basic contact information.
    /// </summary>
    public class Contact
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the Contact class, with the given information.
        /// </summary>
        /// <param name="displayName">The name by which the contact will be displayed.</param>
        /// <param name="email">The contact's email address.</param>
        /// <param name="phone">The contact's phone number.</param>
        public Contact(string displayName, string email, string phone)
        {
            DisplayName = displayName;
            EmailAddress = email;
            PhoneNumber = phone;
        }
    }
}
