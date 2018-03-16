using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Assignment
{
    /// <summary>
    /// This class inherits from Person.
    /// </summary>
    // Required for Binary serialization.
    [Serializable]
    // Required for DataContract serialization.
    [DataContract]
    public class Male: Person
    {
        /// <summary>
        /// Assigns the name to the name on the base class of Person.
        /// </summary>
        /// <param name="name"> 
        /// Name assigned to the object when it is created. 
        /// </param>
        public Male(string name = null) : base(name)
        {
        }
    }
}
