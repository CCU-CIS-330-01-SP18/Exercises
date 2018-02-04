namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Interface to allow for locating instances of the class.
    /// </summary>
    interface ILocatable
    {
        /// <summary>
        /// Return the individual's current location.
        /// </summary>
        /// <returns>A string containing the individual's location.</returns>
        string Locate();
    }
}
