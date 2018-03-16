using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week9Serialization
{
    /// <summary>
    /// Represents an instance of an individual device.
    /// </summary>
    [DataContract]
    [Serializable]
    class Device
    {
        [DataMember]
        private int price;

        [DataMember]
        private string manufacturer;

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public string Manufacturer { get; set; }

        public Device()
        {
            this.manufacturer = "Apple";
            this.price = 1000;
        }
    }

    
}
