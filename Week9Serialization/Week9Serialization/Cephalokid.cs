using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Serialization
{
    /// <summary>
    /// Represents a cephalopod/human hybrid.
    /// </summary>
    /// <remarks>If you're Googling this, you don't get the reference.</remarks>
    class Cephalokid : ISerializer
    {
        private int age;
        private InkColor primaryColor;

        public double SkillLevel;
        public string Name;
        public InkColor PrimaryColor
        {
            get
            {
                return primaryColor;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
        }

        /// <summary>
        /// Creates a new instance of the Cephalokid class, with the given parameters.
        /// </summary>
        /// <param name="name">The kid's name.</param>
        /// <param name="age">The kid's age in years.</param>
        /// <param name="color">The kid's default ink color.</param>
        public Cephalokid(string name, int age, InkColor color)
        {
            this.Name = name;
            this.age = age;
            this.primaryColor = color;
            this.SkillLevel = 1000;
        }

        /// <summary>
        /// Increments age by one year.
        /// </summary>
        /// <returns>The kid's new age.</returns>
        public int Birthday()
        {
            this.age++;
            return this.age;
        }

        /// <summary>
        /// Sets up the first eight kids in a list of entrants for a match of Turf Wars, and simulates the match's play based on the kids' skill levels.
        /// </summary>
        /// <param name="entrants">A collection containing the kids to enter in the match.</param>
        /// <returns>A list containing the members of the winning team.</returns>
        public static List<Cephalokid> TurfWar(ICollection<Cephalokid> entrants)
        {
            var rand = new Random();
            double luck;
            double[] totalSkillLevels = new double[2];
            var teams = new List<Cephalokid>[2]
            {
                new List<Cephalokid>(),
                new List<Cephalokid>()
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

        public byte[] Serialize()
        {
            throw new NotImplementedException();
        }

        public object Deserialize(byte[] serialized)
        {
            throw new NotImplementedException();
        }
    }
}
