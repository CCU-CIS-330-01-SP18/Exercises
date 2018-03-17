using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week9Serialization
{
    /// <summary>
    /// Represents an instance of an individual computer.
    /// </summary>
    [DataContract]
    [Serializable]
    class Computer: Device
    {
        [DataMember]
        public int RAM { get; set; }

        public Computer()
        {
            this.RAM = 5000000;
            this.Price = 5000;
        }
    }
}
