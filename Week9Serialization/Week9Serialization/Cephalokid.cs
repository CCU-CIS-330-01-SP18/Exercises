using System;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a cephalopod/human hybrid.
    /// </summary>
    /// <remarks>If you're Googling this, you don't get the reference.</remarks>
    [DataContract]
    [Serializable]
    public class Cephalokid
    {
        [DataMember]
        private string primaryColor;
        [DataMember]
        private double skillLevel;

        [DataMember]
        public double SkillLevel
        {
            get
            {
                return skillLevel;
            }
            set
            {
                skillLevel = value;
            }
        }
        [DataMember]
        public string Name
        {
            get; set;
        }
        [DataMember]
        public string PrimaryColor
        {
            get
            {
                return primaryColor;
            }
            set
            {
                primaryColor = value;
            }
        }

        /// <summary>
        /// Creates a new instance of the Cephalokid class, with the given parameters.
        /// </summary>
        /// <param name="name">The kid's name.</param>
        /// <param name="color">The kid's default ink color.</param>
        public Cephalokid(string name, string color)
        {
            Name = name;
            PrimaryColor = color;
            SkillLevel = 1000;
        }
    }
}
