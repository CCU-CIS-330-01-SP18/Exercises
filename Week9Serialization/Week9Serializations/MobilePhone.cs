using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week9Serializations
{
    /// <summary>
    /// Represents an instance of an individual mobile phone.
    /// </summary>
    [DataContract]
    [Serializable]
    public class MobilePhone: Device, IEquatable<MobilePhone>
    {
        [DataMember]
        public string Carrier { get; set; }

        public MobilePhone()
        {
            this.Carrier = "Verizon Slightly-Wired";
            this.Price = 500;
        }

        public bool Equals(MobilePhone other)
        {
            if (other.Price == this.Price
                && other.Manufacturer == this.Manufacturer
                && other.Carrier == this.Carrier)
            {
                return true;
            }
            return false;
        }
    }
}
