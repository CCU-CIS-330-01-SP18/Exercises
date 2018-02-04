namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an individual human contact.
    /// </summary>
    public class Individual : Contact, ILocatable, ITransplantOrgan
    {
        private int numberOfRemainingKidneys = 2;
        private int numberOfRemainingLungs = 2;

        public Gender Gender { get; set; }
        public int NumberOfRemainingKidneys
        {
            get
            {
                return numberOfRemainingKidneys;
            }
        }
        public int NumberOfRemainingLungs
        {
            get
            {
                return numberOfRemainingLungs;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Individual class.
        /// </summary>
        public Individual()
        {
            
        }

        /// <summary>
        /// Return the individual's current location.
        /// </summary>
        /// <returns>A string containing the individual's location.</returns>
        /// <remarks>Implements ILocatable.</remarks>
        public string Locate()
        {
            // As we all know, North America is the only continent that exists in real life.
            var possibleLocations = new string[] { "United States of America", "Canada", "Mexico" };
            System.Random random = new System.Random();
            return possibleLocations[random.Next(3)];
        }

        /// <summary>
        /// Attempts to remove an organ of the specified type from the entity. Entities may have a minimum of 1 organ.
        /// </summary>
        /// <param name="organType">The type of organ to remove.</param>
        /// <returns>Whether or not the operation was carried out.</returns>
        public bool RemoveOrgan(Organ organType)
        {
            if (organType == Organ.Kidney)
            {
                if (this.NumberOfRemainingKidneys > 1)
                {
                    this.numberOfRemainingKidneys--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (organType == Organ.Lung)
            {
                if (this.NumberOfRemainingLungs > 1)
                {
                    this.numberOfRemainingLungs--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to transplant an organ of the specified type into the entity. Entities may have a maximum of 2 organs.
        /// </summary>
        /// <param name="organType">The type of organ to transplant.</param>
        /// <returns>Whether or not the operation was carried out.</returns>
        /// <remarks>All humans are compatible in this program.</remarks>
        public bool TransplantOrgan(Organ organType)
        {
            if (organType == Organ.Kidney)
            {
                if (this.NumberOfRemainingKidneys < 2)
                {
                    this.numberOfRemainingKidneys++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (organType == Organ.Lung)
            {
                if (this.NumberOfRemainingLungs < 2)
                {
                    this.numberOfRemainingLungs++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
