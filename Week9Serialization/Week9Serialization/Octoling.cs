using System;
using System.Runtime.Serialization;

namespace Week9Serialization
{
    /// <summary>
    /// Represents an octokid. May be sanitized, which grants a flat bonus to skill level but weakens further skill growth.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Octoling : Cephalokid
    {
        [DataMember]
        private double skillLevel;

        [DataMember]
        public bool Sanitized
        {
            get; set;
        }

        [DataMember]
        new public double SkillLevel
        {
            get
            {
                return skillLevel;
            }
            set
            {
                if (this.Sanitized)
                {
                    skillLevel = value / 4;
                }
                else
                {
                    skillLevel = value;
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the Octoling class, with the given parameters.
        /// </summary>
        /// <param name="name">The octokid's name.</param>
        /// <param name="color">The octokid's default ink color.</param>
        public Octoling(string name, InkColor color) : base(name, color)
        {

        }

        /// <summary>
        /// Sanitizes the Octoling, giving them an immediate and massive boost in power but slowing future skill growth.
        /// </summary>
        public void Sanitize()
        {
            if (!this.Sanitized)
            {
                this.Sanitized = true;
                this.SkillLevel = this.SkillLevel * 2;
            }
        }
    }
}
