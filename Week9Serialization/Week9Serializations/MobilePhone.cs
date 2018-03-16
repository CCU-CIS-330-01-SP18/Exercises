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
    public class MobilePhone: Device
    {
        [DataMember]
        public string Carrier { get; set; }

        public MobilePhone()
        {
            this.Carrier = "Verizon Slightly-Wired";
            this.Price = 500;
        }
    }
}
