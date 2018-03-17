using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week9Serializations
{
    /// <summary>
    /// Represents an instance of an individual device.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Device: IEquatable<Device>
    {
        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public string Manufacturer { get; set; }

        public Device()
        {
            this.Manufacturer = "Apple";
            this.Price = 1000;
        }

        public bool Equals(Device other)
        {
            if (other.Price == this.Price
                && other.Manufacturer == this.Manufacturer)
            {
                return true;
            }
            return false;
        }
    }

    
}
