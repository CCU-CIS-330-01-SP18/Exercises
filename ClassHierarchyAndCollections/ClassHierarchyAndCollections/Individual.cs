namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an individual human contact.
    /// </summary>
    public class Individual : Contact, ILocatable
    {
        // TODO: Need properties here

        /// <summary>
        /// Initializes a new instance of the Individual class.
        /// </summary>
        public Individual()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the Individual class.
        /// </summary>
        /// <param name="name">The individual's display name.</param>
        public Individual(string name)
        {
            this.DisplayName = name;
        }
    }
}
