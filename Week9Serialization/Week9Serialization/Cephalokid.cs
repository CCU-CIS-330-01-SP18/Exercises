using System;
using System.Collections.Generic;
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
        private InkColor primaryColor;
        private double skillLevel;

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
        public string Name
        {
            get; set;
        }
        public InkColor PrimaryColor
        {
            get
            {
                return primaryColor;
            }
        }

        /// <summary>
        /// Creates a new instance of the Cephalokid class, with the given parameters.
        /// </summary>
        /// <param name="name">The kid's name.</param>
        /// <param name="color">The kid's default ink color.</param>
        public Cephalokid(string name, InkColor color)
        {
            this.Name = name;
            this.primaryColor = color;
            this.SkillLevel = 1000;
        }

        /// <summary>
        /// Sets up the first eight kids in a list of entrants for a match of Turf Wars, and simulates the match's play based on the kids' skill levels.
        /// </summary>
        /// <param name="entrants">A collection containing the kids to enter in the match.</param>
        /// <returns>A Team object, containing the members of the winning team.</returns>
        public static Team<Cephalokid> TurfWar(ICollection<Cephalokid> entrants)
        {
            var rand = new Random();
            double luck;
            double[] totalSkillLevels = new double[2];
            var teams = new Team<Cephalokid>[2]
            {
                new Team<Cephalokid>(),
                new Team<Cephalokid>()
            };

            // Randomly assign kids to teams until there are four on each.
            foreach (Cephalokid entrant in entrants)
            {
                int random = rand.Next(2);
                if (teams[random].Count <= 4)
                {
                    teams[random].Add(entrant);
                }
                else if (random == 0)
                {
                    teams[1].Add(entrant);
                }
                else if (random == 1)
                {
                    teams[0].Add(entrant);
                }
            }

            // Add up the kids' skill levels on each team.
            for (int i = 0; i < teams.Length; i++)
            {
                foreach (Cephalokid player in teams[i])
                {
                    totalSkillLevels[i] += player.SkillLevel;
                }
            }

            // Individual skill isn't everything.
            luck = rand.NextDouble() + 0.5;
            totalSkillLevels[0] = totalSkillLevels[0] * luck;
            luck = rand.NextDouble() + 0.5;
            totalSkillLevels[1] = totalSkillLevels[1] * luck;

            if (totalSkillLevels[0] >= totalSkillLevels[1])
            {
                return teams[0];
            }
            else
            {
                return teams[1];
            }
        }
    }
}
