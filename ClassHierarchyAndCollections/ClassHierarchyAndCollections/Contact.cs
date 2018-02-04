using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    public class Contact : ILocatable
    {
        private string location;
        public string DisplayName { get; set; }

        public string LegalName { get; set; }

        public Contact(string location)
        {
            this.Location = location;
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string GetLocation()
        {
            return location;
        }
    }
}
