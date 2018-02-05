namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents an employee for one or more businesses.
    /// </summary>
    public class Employee : Individual, IPay
    {
        public bool Exempt { get; set; }
        public int Happiness { get; set; }
        public string UnionMembership { get; set; }
        public decimal Wallet { get; set; } = 0.00m;

        /// <summary>
        /// Initializes a new instance of the Employee class.
        /// </summary>
        public Employee()
        {

        }

        /// <summary>
        /// Attempts to pay the requested amount, deducting it from this entity's money reserves and returning the value paid.
        /// </summary>
        /// <param name="paymentRequested">The amount of payment requested by the seller.</param>
        /// <returns>A decimal amount equal to the amount requested, or 0.00m if the payment could not be processed.</returns>
        public decimal Pay(decimal paymentRequested)
        {
            if (paymentRequested <= Wallet)
            {
                Wallet -= paymentRequested;
                return paymentRequested;
            }
            else
            {
                Happiness--;
                return 0.00m;
            }
        }

        /// <summary>
        /// Attempts to purchase the given item at the requested amount. Works the same way as <see cref="Pay(decimal)"/>.
        /// </summary>
        /// <param name="paymentRequested">The amount of payment requested by the seller.</param>
        /// <param name="purchaseName">The name of the product being purchased.</param>
        /// <returns>A decimal amount equal to the amount requested, or 0.00m if the payment could not be processed.</returns>
        public decimal Purchase(decimal paymentRequested, string purchaseName)
        {
            // Method here to satisfy requirements of IPay; instances of the Employee class cannot own things apart from the company that owns them.
            return Pay(paymentRequested);
        }

        /// <summary>
        /// Receives the payment offered and adds it to this entity's money reserves.
        /// </summary>
        /// <param name="paymentOffered">The amount of payment to offer.</param>
        public void ReceivePayment(decimal paymentOffered)
        {
            if (paymentOffered > 0.00m)
            {
                Wallet += paymentOffered;
                Happiness++;
            }
        }
    }
}
