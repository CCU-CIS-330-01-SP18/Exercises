using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeglectThoseDuties
{
    /// <summary>
    /// Neglects your duties so you feel less bad about neglecting your duties.
    /// </summary>
    public class NeglectDuties
    {
        /// <summary>
        /// Prints a statment informing the user that the supplied duties have been neglected.
        /// </summary>
        /// <param name="duties">The duties to be neglected.</param>
        /// <returns>Will return true once the neglected duties statement has been written.</returns>
        public static bool NeglectMyDuties(string duties)
        {
            bool hasBeenNeglected = false;
            Console.WriteLine("Your duty to '" + duties + "' has officially been neglected.");
            hasBeenNeglected = true;
            return hasBeenNeglected;
        }
    }
}
