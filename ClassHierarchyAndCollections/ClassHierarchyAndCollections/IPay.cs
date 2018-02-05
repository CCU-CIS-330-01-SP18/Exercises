using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Interface to implement that allows one to pay or be paid for products and services.
    /// </summary>
    interface IPay
    {
        /// <summary>
        /// Attempts to pay the requested amount, deducting it from this entity's money reserves and returning the value paid.
        /// </summary>
        /// <param name="paymentRequested">The amount of payment requested by the seller.</param>
        /// <returns>A decimal amount equal to the amount requested, or 0.00m if the payment could not be processed.</returns>
        decimal Pay(decimal paymentRequested);

        /// <summary>
        /// Receives the payment offered and adds it to this entity's money reserves.
        /// </summary>
        /// <param name="paymentOffered">The amount of payment to offer.</param>
        void ReceivePayment(decimal paymentOffered);
    }
}
