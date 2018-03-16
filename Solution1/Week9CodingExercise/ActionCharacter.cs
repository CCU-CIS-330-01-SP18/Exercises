using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Week9CodingExercise
{
    /// <summary>
    /// A Serializable class that represents a person Character.
    /// </summary>
    /// 
    [Serializable]
    [DataContract]
    public class ActionCharacter
    {
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Class constructor for Character.
        /// </summary>
        /// <param name="name">Character's name.</param>
        public ActionCharacter(string name)
        {
            Name = name;
        }
    }
}
