using System.Collections.Generic;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an association of individual members.
    /// Unlike other Organizations, Associations make decisions by voting.
    /// </summary>
    public class Association : Organization
    {
        // The new keyword is used so that this property "overrides" the one from Organization, in a way.
        // This is necessary because this list must contain Members and no other type of Individual.
        //public new List<Member> Roster { get; set; }

        /// <summary>
        /// Initializes a new instance of the Association class.
        /// </summary>
        public Association()
        {
            Roster = new List<Individual>();
        }

        /// <summary>
        /// Put something up to a vote of all the members.
        /// </summary>
        /// <returns>An array of two integers: index 0 represents "yea" votes, and index 1 represents "nay" votes.</returns>
        public int[] Vote()
        {
            int[] tally = new int[2] { 0, 0 };
            if (Roster.Count == 0)
            {
                return tally;
            }
            foreach (Member member in Roster)
            {
                var vote = member.Vote();
                switch (vote)
                {
                    case VoteType.Yea:
                        tally[0]++;
                        break;

                    case VoteType.Nay:
                        tally[1]++;
                        break;

                    default:
                        break;
                }
            }
            return tally;
        }
    }
}
