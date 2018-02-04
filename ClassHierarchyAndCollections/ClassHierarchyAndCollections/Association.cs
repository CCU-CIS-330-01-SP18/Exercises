namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an association of individual members.
    /// Unlike other Organizations, Associations make decisions by voting.
    /// </summary>
    public class Association : Organization
    {
        /// <summary>
        /// Vote on a given proposal, with the given number of members voting.
        /// </summary>
        /// <param name="proposal">The proposal to vote on.</param>
        /// <param name="numberOfMembers">The number of members voting on this proposal.</param>
        /// <returns>An array of two integers: index 0 represents "yea" votes, and index 1 represents "nay" votes.</returns>
        public int[] Vote(string proposal, int numberOfMembers)
        {
            throw new System.NotImplementedException();
        }
    }
}
