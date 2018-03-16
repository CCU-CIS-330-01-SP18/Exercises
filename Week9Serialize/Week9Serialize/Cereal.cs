using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week9Serialization
{
    /// <summary>
    /// A breakfast cereal.
    /// </summary>
    [Serializable]
    public class Cereal
    {
        public enum CerealFlavor { Chocolate, Fruit, Honey, Granola, Cinnamon, Maple, Sugar };
        public enum CerealSize { Small, Medium, Large };
        [DataMember]
        public readonly string Name;
        [DataMember]
        public readonly bool Generic;
        [DataMember]
        public readonly CerealFlavor Flavor;
        [DataMember]
        public readonly CerealSize Size;

        /// <summary>
        /// A constructor for the cereal type.
        /// </summary>
        /// <param name="name">The name of the cereal.</param>
        /// <param name="generic">Whether or not the cereal is a name brand.</param>
        /// <param name="flavor">The flavor of the cereal.</param>
        /// <param name="size">The relative size of the cereal pieces.</param>
        public Cereal(string name, bool generic, CerealFlavor flavor, CerealSize size)
        {
            Name = name;
            Generic = generic;
            Flavor = flavor;
            Size = size;
        }
    }
}
