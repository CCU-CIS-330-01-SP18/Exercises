using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12Reflection
{
    /// <summary>
    /// A class representing the Holy Hand Grenade of Antioch, for use in reflection.
    /// </summary>
    public class HolyHandGrenade
    {
        public bool IsHoly { get; set; }

        public bool HasBlownEnemiesToTinyBits { get; set; }

        /// <summary>
        /// Retrieves the section of "scripture" the Holy Hand Grenade is mentioned in from the "Bible".
        /// </summary>
        /// <returns>A string, containing the "Bible verse".</returns>
        public string GetVerseFromBible()
        {
            return "Armaments 2:9-21 " +
                "And the LORD spake, saying, \"First shalt thou take out the Holy " +
                "Pin, then shalt thou count to three, no more, no less. Three shall be the number " +
                "thou shalt count, and the number of the counting shall be three. Four shalt thou " +
                "not count, neither count thou two, excepting that thou then proceed to three. Five " +
                "is right out. Once the number three, being the third number, be reached, then lobbest " +
                "thou thy Holy Hand Grenade of Antioch towards thy foe, who, being naughty in My sight, " +
                "shall snuff it.";
        }
    }
}
