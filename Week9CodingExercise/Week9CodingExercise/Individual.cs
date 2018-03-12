using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week9CodingExercise
{
    [Serializable]

    [DataContract]
    public class Individual
    {
        
        //private string gender;
        public Individual(string name = null)
        {
            Name = name;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsMale { get; set; }
        /*public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender.ToLower();
                if (gender == "male" || gender == "female")
                {
                    gender = value;
                }
                else
                {
                    throw new FormatException("Entry Must Be Either 'Male' or 'Female', no other genders are recognized at this time.");
                }
            }
        }*/

        [DataMember]
        public bool IsEmployee { get; set; }


    }
}
