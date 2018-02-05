using System.Collections.Generic;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an association of individual members.
    /// Unlike other Organizations, Associations make decisions by voting.
    /// </summary>
    public class Association : Organization
    {
        public List<string> KeyTenets { get; set; }
        public bool IsACult { get; set; }

        /// <summary>
        /// Initializes a new instance of the Association class.
        /// </summary>
        public Association() : base()
        {
            KeyTenets = new List<string>();
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
