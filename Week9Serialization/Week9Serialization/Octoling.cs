using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// Represents an octokid. May be sanitized, which grants a flat bonus to skill level but weakens further skill growth.
    /// </summary>
    class Octoling : Cephalokid, ISerializer
    {
        private bool sanitized;

        public bool Sanitized
        {
            get
            {
                return sanitized;
            }
        }

        new public double SkillLevel
        {
            get
            {
                return SkillLevel;
            }
            set
            {
                if (this.Sanitized)
                {
                    SkillLevel = value / 4;
                }
                else
                {
                    SkillLevel = value;
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the Octoling class, with the given parameters.
        /// </summary>
        /// <param name="name">The octokid's name.</param>
        /// <param name="age">The octokid's age in years.</param>
        /// <param name="color">The octokid's default ink color.</param>
        public Octoling(string name, int age, InkColor color) : base(name, age, color)
        {

        }

        /// <summary>
        /// Sanitizes the Octoling, giving them an immediate and massive boost in power but slowing future skill growth.
        /// </summary>
        public void Sanitize()
        {
            if (!this.Sanitized)
            {
                this.sanitized = true;
                this.SkillLevel = this.SkillLevel * 2;
            }
        }
    }
}
