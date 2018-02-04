namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Enumeration for voting personalities. Different personalities have different behaviors while voting.
    /// </summary>
    public enum Personality
    {
        // Yes Man always votes true.
        YesMan,
        // Grouchy Jerk always votes false.
        GrouchyJerk,
        // Swing Voter has a chance of voting either, 50/50.
        SwingVoter,
        // Overly Deliberative works like Swing Voter, but with a 50% chance of failing to vote at all.
        OverlyDeliberative
    }
}
