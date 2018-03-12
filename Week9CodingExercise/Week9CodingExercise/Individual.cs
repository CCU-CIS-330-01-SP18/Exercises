using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    /// <summary>
    /// Instantiates an Individual Object.
    /// </summary>
    [Serializable]

    [DataContract]
    public class Individual
    {
        
        //private string gender;
        /// <summary>
        /// Constructor that sets the name of the Individual.
        /// </summary>
        /// <param name="name"></param>
        public Individual(string name = null)
        {
            Name = name;
        }

        [DataMember]
        public string Name { get; set; }


        [DataMember]
        public bool IsMale { get; set; }


        [DataMember]
        public bool IsEmployee { get; set; }


    }
}
