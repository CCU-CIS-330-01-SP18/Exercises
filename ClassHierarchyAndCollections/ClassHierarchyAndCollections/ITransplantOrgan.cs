namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Interface to allow for the removal and transplanting of organs.
    /// </summary>
    /// <remarks>Yes, I went there.</remarks>
    interface ITransplantOrgan
    {
        /// <summary>
        /// Attempts to remove an organ of the specified type from the entity. Entities may have a minimum of 1 organ.
        /// </summary>
        /// <param name="organType">The type of organ to remove.</param>
        /// <returns>Whether or not the operation was carried out.</returns>
        bool RemoveOrgan(Organ organType);

        /// <summary>
        /// Attempts to transplant an organ of the specified type into the entity. Entities may have a maximum of 2 organs.
        /// </summary>
        /// <param name="organType">The type of organ to transplant.</param>
        /// <returns>Whether or not the operation was carried out.</returns>
        /// <remarks>All humans are compatible.</remarks>
        bool TransplantOrgan(Organ organType);
    }
}
