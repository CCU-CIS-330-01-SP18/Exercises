using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serializeation
{
    /// <summary>
    /// This class inherits from Weapons and has a name for functional purposes.
    /// </summary>
    // Required for Binary serialization.
    [Serializable]
    // Required for DataContract serialization.
    [DataContract]
    public class Sabre : Weapon
    {
        /// <summary>
        /// Assigns the name to the name on the base class of Weapon.
        /// </summary>
        /// <param name="name"> 
        /// This is the name assigned to the object when it is created. 
        /// </param>
        public Sabre(string name = null) : base(name)
        {
        }
    }
}
