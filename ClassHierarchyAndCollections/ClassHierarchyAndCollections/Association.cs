using System.Collections.Generic;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an association of individual members.
    /// Unlike other Organizations, Associations make decisions by voting.
    /// </summary>
    public class Association : Organization
    {
        /// <summary>
        /// Initializes a new instance of the Association class.
        /// </summary>
        public Association()
        {
            roster = new List<Individual>();
        }

        /// <summary>
        /// Expels the given member from the association and removes them from the roster.
        /// </summary>
        /// <param name="member">The member to remove.</param>
        public void ExpelMember(Member member)
        {
            if (roster.Contains(member))
            {
                roster.Remove(member);
            }
        }

        /// <summary>
        /// Inducts a new member into the association and adds them to the roster.
        /// </summary>
        /// <param name="newMember">The member to induct.</param>
        public void InductMember(Member newMember)
        {
            if (!roster.Contains(newMember))
            {
                roster.Add(newMember);
            }
        }

        /// <summary>
        /// Put something up to a vote of all the members.
        /// </summary>
        /// <returns>An array of two integers: index 0 represents "yea" votes, and index 1 represents "nay" votes.</returns>
        public int[] Vote()
        {
            int[] tally = new int[2] { 0, 0 };
            if (roster.Count == 0)
            {
                return tally;
            }
            foreach (Member member in roster)
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
