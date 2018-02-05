using System.Collections.Generic;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a business, containing <see cref="Employee"/>s and products.
    /// </summary>
    public class Business : Organization, IPay
    {
        public BusinessType BusinessType { get; set; }
        public decimal Cash { get; set; } = 0.00m;
        public Dictionary<string, decimal> Products { get; set; }

        /// <summary>
        /// Initializes a new instance of the Business class.
        /// </summary>
        public Business() : base()
        {
            Products = new Dictionary<string, decimal>();
        }

        /// <summary>
        /// Attempts to sell a product with the given name to the given customer.
        /// </summary>
        /// <param name="productName">The name of the product to sell.</param>
        /// <param name="customer">The client to sell the product to.</param>
        /// <returns>Returns true if the sale was completed, and false if it did not complete.</returns>
        public bool SellProduct(string productName, Client customer)
        {
            if (Products.ContainsKey(productName) && customer.Wallet >= Products[productName])
            {
                ReceivePayment(customer.Pay(Products[productName]));
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to pay the requested amount, deducting it from this entity's money reserves and returning the value paid.
        /// </summary>
        /// <param name="paymentRequested">The amount of payment requested by the seller.</param>
        /// <returns>A decimal amount equal to the amount requested, or 0.00m if the payment could not be processed.</returns>
        public decimal Pay(decimal paymentRequested)
        {
            if (paymentRequested <= Cash)
            {
                Cash -= paymentRequested;
                return paymentRequested;
            }
            else
            {
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
            // Businesses purchase things in order to sell them at a markup.
            decimal payment = Pay(paymentRequested);
            if (payment > 0.00m && !Products.ContainsKey(purchaseName))
            {
                Products.Add(purchaseName, paymentRequested * 1.1m);
            }
            return payment;
        }

        /// <summary>
        /// Receives the payment offered and adds it to this entity's money reserves.
        /// </summary>
        /// <param name="paymentOffered">The amount of payment to offer.</param>
        public void ReceivePayment(decimal paymentOffered)
        {
            if (paymentOffered > 0.00m)
            {
                Cash += paymentOffered;
            }
        }

        /// <summary>
        /// Pays all of the <see cref="Employee"/>s in the business the given amount.
        /// </summary>
        /// <param name="paycheck">The amount to pay each employee.</param>
        /// <remarks>In OUR businesses, everyone gets paid exactly the same amount.</remarks>
        public void PayDay(decimal paycheck)
        {
            foreach (Employee employee in Roster)
            {

            }
        }
    }
}
