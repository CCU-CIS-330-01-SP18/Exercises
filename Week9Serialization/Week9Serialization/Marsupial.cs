using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;

namespace Week9Serialization
{
    /// <summary>
    /// Represents the top of the hierarchy and a class that could be serialized.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Marsupial
    {
        /// <summary>
        /// Contructs the object with various properties.
        /// </summary>
        /// <param name="name">Represents the name.</param>
        public Marsupial(string name = null)
        {
            Name = name;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public int NumberOfLegs
        {
            get;
            set;
        }

        [DataMember]
        public bool Deadly
        {
            get;
            set;
        }

        [DataMember]
        public bool Adorable
        {
            get;
            set;
        }

    }
}

