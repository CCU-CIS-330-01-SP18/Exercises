using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week9Serializations
{
    /// <summary>
    /// Represents an instance of an individual computer.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Computer: Device, IEquatable<Computer>
    {
        [DataMember]
        public int RAM { get; set; }

        public Computer()
        {
            this.RAM = 5000000;
            this.Price = 5000;
        }

        public bool Equals(Computer other)
        {
            if (other.Price == this.Price
                && other.Manufacturer == this.Manufacturer
                && other.RAM == this.RAM)
            {
                return true;
            }
            return false;
        }
    }
}
