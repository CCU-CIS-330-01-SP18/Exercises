using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Week9Serializeation
{
    /// <summary>
    /// This is a serializable class which contains a few properties for weapons.
    /// </summary>
    // Required for Binary serialization.
    [Serializable]
    // Required for DataContract serialization.
    [DataContract]
    public class Weapon
    {
        public Weapon(string name = null)
        {
            string Name = name;

            Console.WriteLine("A {0} named {1} was constructed.", this.GetType().Name, name ?? "<null>");
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public float Size { get; set; }
    }
}
